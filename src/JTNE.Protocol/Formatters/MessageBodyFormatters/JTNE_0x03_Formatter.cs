using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x03_Formatter : IJTNEFormatter<JTNE_0x03>
    {
        public JTNE_0x03 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            JTNE_0x03 jTNE_0X03 = new JTNE_0x03();
            jTNE_0X03.Supplement= JTNEFormatterExtensions.GetFormatter<JTNE_0x02>().Deserialize(bytes, out readSize);
            return jTNE_0X03;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x03 value)
        {
            offset = JTNEFormatterExtensions.GetFormatter<JTNE_0x02>().Serialize(ref bytes, offset,value.Supplement);
            return offset;
        }
    }
}
