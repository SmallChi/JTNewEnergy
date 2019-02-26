using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x03_Platform_Formatter : IJTNEFormatter<JTNE_0x03_Platform>
    {
        public JTNE_0x03_Platform Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            JTNE_0x03_Platform jTNE_0X03_Platform = new JTNE_0x03_Platform();
            jTNE_0X03_Platform.Supplement= JTNEFormatterExtensions.GetFormatter<JTNE_0x02_Platform>().Deserialize(bytes, out readSize);
            return jTNE_0X03_Platform;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x03_Platform value)
        {
            offset = JTNEFormatterExtensions.GetFormatter<JTNE_0x02_Platform>().Serialize(ref bytes, offset,value.Supplement);
            return offset;
        }
    }
}
