using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x02_0x05_Formatter : IJTNEFormatter<JTNE_0x02_0x05>
    {
        public JTNE_0x02_0x05 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0x05 jTNE_0X02_0X05 = new JTNE_0x02_0x05();
            jTNE_0X02_0X05.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X05.PositioStatus = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X05.Lng = JTNEBinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jTNE_0X02_0X05.Lat = JTNEBinaryExtensions.ReadUInt32Little(bytes, ref offset);
            readSize = offset;
            return jTNE_0X02_0X05;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0x05 value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.TypeCode);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.PositioStatus);
            offset += JTNEBinaryExtensions.WriteUInt32Little(bytes, offset, value.Lng);
            offset += JTNEBinaryExtensions.WriteUInt32Little(bytes, offset, value.Lat);
            return offset;
        }
    }
}
