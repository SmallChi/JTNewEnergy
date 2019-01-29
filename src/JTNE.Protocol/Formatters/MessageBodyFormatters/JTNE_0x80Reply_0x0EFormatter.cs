using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x80Reply_0x0EFormatter : IJTNEFormatter<JTNE_0x80Reply_0x0E>
    {
        public JTNE_0x80Reply_0x0E Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x80Reply_0x0E jTNE_0x80Reply_0x0E= new JTNE_0x80Reply_0x0E();
            jTNE_0x80Reply_0x0E.ParamValue = JTNEBinaryExtensions.ReadBytesLittle(bytes, ref offset);
            jTNE_0x80Reply_0x0E.ParamLength = (byte)bytes.Length;
            readSize = offset;
            return jTNE_0x80Reply_0x0E;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x80Reply_0x0E value)
        {
            offset += JTNEBinaryExtensions.WriteBytesLittle(bytes, offset, value.ParamValue);
            return offset;
        }
    }
}
