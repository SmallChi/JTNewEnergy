using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x81_Device_Formatter : IJTNEFormatter<JTNE_0x81_Device>
    {
        public JTNE_0x81_Device Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x81_Device jTNE_0X81_Device = new JTNE_0x81_Device();
            jTNE_0X81_Device.OperateTime = JTNEBinaryExtensions.ReadDateTime6Little(bytes, ref offset);
            jTNE_0X81_Device.ParamNum = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            for (int i = 0; i < jTNE_0X81_Device.ParamNum; i++)
            {
                var paramId = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);//参数ID         
                int readSubBodySize = 0;
                if (JTNE_0x81_Body_Device.JTNE_0x81Method.TryGetValue(paramId, out Type type))
                {
                    ReadOnlySpan<byte> readOnlySpan = new ReadOnlySpan<byte>();
                    if (JTNE_0x81_Body_Device.JTNE_0x81LengthOfADependOnValueOfB.TryGetValue(paramId, out byte dependOnParamId)) {
                        var length = jTNE_0X81_Device.ParamList.FirstOrDefault(m => m.ParamId == dependOnParamId).ParamLength;
                        int tempOffset = 0;
                        int lengthVal = JTNEBinaryExtensions.ReadByteLittle(bytes.Slice(offset - length - 1, length), ref tempOffset);
                        readOnlySpan = bytes.Slice(offset, lengthVal);
                    }
                    else {
                        readOnlySpan = bytes.Slice(offset);
                    }
                    if (jTNE_0X81_Device.ParamList != null)
                    {
                        jTNE_0X81_Device.ParamList.Add(JTNEFormatterResolverExtensions.JTNEDynamicDeserialize(JTNEFormatterExtensions.GetFormatter(type), readOnlySpan, out readSubBodySize));
                    }
                    else
                    {
                        jTNE_0X81_Device.ParamList = new List<JTNE_0x81_Body_Device> { JTNEFormatterResolverExtensions.JTNEDynamicDeserialize(JTNEFormatterExtensions.GetFormatter(type), readOnlySpan, out readSubBodySize) };
                    }
                }
                offset = offset + readSubBodySize;
            }
            readSize = offset;
            return jTNE_0X81_Device;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x81_Device value)
        {
            offset += JTNEBinaryExtensions.WriteDateTime6Little(bytes, offset, value.OperateTime);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.ParamNum);
            foreach (var item in value.ParamList)
            {
                offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, item.ParamId);
                object obj = JTNEFormatterExtensions.GetFormatter(item.GetType());
                offset = JTNEFormatterResolverExtensions.JTNEDynamicSerialize(obj, ref bytes, offset, item);
            }
            return offset;
        }
    }
}
