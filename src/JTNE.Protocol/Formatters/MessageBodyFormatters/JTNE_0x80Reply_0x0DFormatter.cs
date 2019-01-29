using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x80Reply_0x0DFormatter : IJTNEFormatter<JTNE_0x80Reply_0x0D>
    {
        public JTNE_0x80Reply_0x0D Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x80Reply_0x0D jTNE_0x80Reply_0x0D = new JTNE_0x80Reply_0x0D();
            jTNE_0x80Reply_0x0D.ParamValue = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNE_0x80Reply_0x0D;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x80Reply_0x0D value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.ParamValue);
            return offset;
        }
    }
}
