using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x02_0x04_Formatter : IJTNEFormatter<JTNE_0x02_0x04>
    {
        public JTNE_0x02_0x04 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0x04 jTNE_0X02_0X04 = new JTNE_0x02_0x04();
            jTNE_0X02_0X04.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X04.EngineStatus = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X04.Revs = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X04.FuelRate = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            readSize = offset;
            return jTNE_0X02_0X04;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0x04 value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.TypeCode);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.EngineStatus);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.Revs);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.FuelRate);
            return offset;
        }
    }
}
