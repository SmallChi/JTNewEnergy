using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x02_Formatter : IJTNEFormatter<JTNE_0x02>
    {
        public JTNE_0x02 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0, bodyReadSize = 0;
            JTNE_0x02 jTNE_0X02 = new JTNE_0x02();
            jTNE_0X02.Values = new Dictionary<byte, JTNE_0x02_Body>();
            jTNE_0X02.CusotmValues = new Dictionary<byte, byte[]>();
            while (offset < bytes.Length)
            {
                byte typeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
                if (JTNE_0x02_Body.TypeCodes.TryGetValue(typeCode, out Type jTNE_0x02_BodyImpl))
                {
                    var bodyImplFormatter = JTNEFormatterExtensions.GetFormatter(jTNE_0x02_BodyImpl);
                    //从类型编码开始取 offset - 1
                    var bodyData = JTNEFormatterResolverExtensions.JTNEDynamicDeserialize(bodyImplFormatter, bytes.Slice(offset - 1), out bodyReadSize);
                    jTNE_0X02.Values.Add(typeCode, bodyData);
                    offset += bodyReadSize - 1;
                }
                else if (JTNE_0x02_CustomBody.CustomTypeCodes.TryGetValue(typeCode, out Type jTNE_0x02_CustomBodyImpl))
                {
                    int length = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
                    //从类型编码开始取 offset - 1 - 2
                    //1:类型编码
                    //2:自定义数据长度
                    byte[] customBodyData = bytes.Slice(offset - 1 - 2, length + 1 + 2).ToArray();
                    jTNE_0X02.CusotmValues.Add(typeCode, customBodyData);
                    offset += customBodyData.Length - 1 - 2;
                }
                else
                {
                    offset += bodyReadSize;
                    break;
                }
            }
            readSize = offset;
            return jTNE_0X02;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02 value)
        {
            if (value.Values != null && value.Values.Count > 0)
            {
                foreach (var item in value.Values)
                {
                    if (JTNE_0x02_Body.TypeCodes.TryGetValue(item.Key, out Type jTNE_0x02_BodyImpl))
                    {
                        var bodyImplFormatter = JTNEFormatterExtensions.GetFormatter(jTNE_0x02_BodyImpl);
                        offset = JTNEFormatterResolverExtensions.JTNEDynamicSerialize(bodyImplFormatter, ref bytes, offset, item.Value);
                    }
                }
            }
            if (value.CusotmSerializeObjectValues != null && value.CusotmSerializeObjectValues.Count > 0)
            {
                foreach (var item in value.CusotmSerializeObjectValues)
                {
                    if (JTNE_0x02_CustomBody.CustomTypeCodes.TryGetValue(item.Key, out Type jTNE_0x02_CustomBodyImpl))
                    {
                        var customBodyImplFormatter = JTNEFormatterExtensions.GetFormatter(jTNE_0x02_CustomBodyImpl);
                        offset = JTNEFormatterResolverExtensions.JTNEDynamicSerialize(customBodyImplFormatter, ref bytes, offset, item.Value);
                    }
                }
            }
            return offset;
        }
    }
}
