


using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x81_0x08Formatter : IJTNEFormatter<JTNE_0x81_0x08>
    {
        public JTNE_0x81_0x08 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x81_0x08 jTNE_0x81_0x08 = new JTNE_0x81_0x08();
            jTNE_0x81_0x08.ParamValue = JTNEBinaryExtensions.ReadStringLittle(bytes, ref offset, jTNE_0x81_0x08.ParamLength);
            readSize = offset;
            return jTNE_0x81_0x08;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x81_0x08 value)
        {
            offset += JTNEBinaryExtensions.WriteStringLittle(bytes, offset, value.ParamValue,value.ParamLength);
            return offset;
        }
    }
}
