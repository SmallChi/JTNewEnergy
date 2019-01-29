using JTNE.Protocol.Enums;
using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x82_0x03Formatter : IJTNEFormatter<JTNE_0x82_0x03>
    {
        public JTNE_0x82_0x03 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x82_0x03 jTNE_0x82_0x03 = new JTNE_0x82_0x03();
            jTNE_0x82_0x03.ParamId= JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNE_0x82_0x03;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x82_0x03 value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.ParamId);
            return offset;
        }
    }
}