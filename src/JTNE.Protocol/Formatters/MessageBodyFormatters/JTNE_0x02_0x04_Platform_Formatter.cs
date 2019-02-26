using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x02_0x04_Platform_Formatter : IJTNEFormatter<JTNE_0x02_0x04_Platform>
    {
        public JTNE_0x02_0x04_Platform Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0x04_Platform jTNE_0X02_0X04_Platform = new JTNE_0x02_0x04_Platform();
            jTNE_0X02_0X04_Platform.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X04_Platform.EngineStatus = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X04_Platform.Revs = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X04_Platform.FuelRate = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            readSize = offset;
            return jTNE_0X02_0X04_Platform;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0x04_Platform value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.TypeCode);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.EngineStatus);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.Revs);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.FuelRate);
            return offset;
        }
    }
}
