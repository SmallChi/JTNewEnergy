using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x80Reply_0x01Formatter : IJTNEFormatter<JTNE_0x80Reply_0x01>
    {
        public JTNE_0x80Reply_0x01 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x80Reply_0x01 jTNE_0x80Reply_0x01 = new JTNE_0x80Reply_0x01();
            jTNE_0x80Reply_0x01.ParamValue = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            readSize = offset;
            return jTNE_0x80Reply_0x01;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x80Reply_0x01 value)
        {
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.ParamValue);
            return offset;
        }
    }
}
