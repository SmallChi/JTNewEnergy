using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x80Reply_Formatter : IJTNEFormatter<JTNE_0x80Reply>
    {
        public JTNE_0x80Reply Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            JTNE_0x80Reply jTNE_0x80Reply = new JTNE_0x80Reply();
            jTNE_0x80Reply.JTNE_Reply0x80 = JTNEFormatterExtensions.GetFormatter<JTNE_0x81>().Deserialize(bytes, out readSize);
            return jTNE_0x80Reply;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x80Reply value)
        {
            offset=JTNEFormatterExtensions.GetFormatter<JTNE_0x81>().Serialize(ref bytes, offset,value.JTNE_Reply0x80);
            return offset;
        }
    }
}
