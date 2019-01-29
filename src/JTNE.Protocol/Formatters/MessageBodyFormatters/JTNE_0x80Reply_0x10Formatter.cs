using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x80Reply_0x10Formatter : IJTNEFormatter<JTNE_0x80Reply_0x10>
    {
        public JTNE_0x80Reply_0x10 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x80Reply_0x10 jTNE_0x80Reply_0x10 = new JTNE_0x80Reply_0x10();
            jTNE_0x80Reply_0x10.ParamValue = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNE_0x80Reply_0x10;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x80Reply_0x10 value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset,value.ParamValue);
            return offset;
        }
    }
}
