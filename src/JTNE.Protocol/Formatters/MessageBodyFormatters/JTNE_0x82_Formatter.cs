using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x82_Formatter : IJTNEFormatter<JTNE_0x82>
    {
        public JTNE_0x82 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x82 jTNE_0x82 = new JTNE_0x82();
            jTNE_0x82.ControlTime = JTNEBinaryExtensions.ReadDateTime6Little(bytes, ref offset);
            jTNE_0x82.ParamID = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);//参数ID         

            if (JTNE_0x82_Body.JTNE_0x82Method.TryGetValue(jTNE_0x82.ParamID, out Type type))
            {
                int readSubBodySize = 0;
                jTNE_0x82.Parameter = JTNEFormatterResolverExtensions.JTNEDynamicDeserialize(JTNEFormatterExtensions.GetFormatter(type), bytes.Slice(offset), out readSubBodySize);
                offset = offset + readSubBodySize;
            }
            readSize = offset;
            return jTNE_0x82;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x82 value)
        {
            offset += JTNEBinaryExtensions.WriteDateTime6Little(bytes, offset, value.ControlTime);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.ParamID);
            if (JTNE_0x82_Body.JTNE_0x82Method.TryGetValue(value.ParamID, out Type type))
            {
                offset =JTNEFormatterResolverExtensions.JTNEDynamicSerialize(JTNEFormatterExtensions.GetFormatter(type),ref bytes, offset, value.Parameter);
            }
            return offset;
        }
    }
}
