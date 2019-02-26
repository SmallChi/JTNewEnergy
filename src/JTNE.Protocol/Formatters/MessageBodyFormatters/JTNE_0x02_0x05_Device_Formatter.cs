
using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x02_0x05_Device_Formatter : IJTNEFormatter<JTNE_0x02_0x05_Device>
    {
        public JTNE_0x02_0x05_Device Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0x05_Device jTNE_0X02_0X05_Device = new JTNE_0x02_0x05_Device();
            jTNE_0X02_0X05_Device.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X05_Device.PositioStatus = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X05_Device.Lng = JTNEBinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jTNE_0X02_0X05_Device.Lat = JTNEBinaryExtensions.ReadUInt32Little(bytes, ref offset);
            readSize = offset;
            return jTNE_0X02_0X05_Device;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0x05_Device value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.TypeCode);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.PositioStatus);
            offset += JTNEBinaryExtensions.WriteUInt32Little(bytes, offset, value.Lng);
            offset += JTNEBinaryExtensions.WriteUInt32Little(bytes, offset, value.Lat);
            return offset;
        }
    }
}
