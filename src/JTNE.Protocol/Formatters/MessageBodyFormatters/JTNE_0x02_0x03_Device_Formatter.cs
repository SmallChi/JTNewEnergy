using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x02_0x03_Device_Formatter : IJTNEFormatter<JTNE_0x02_0x03_Device>
    {
        public JTNE_0x02_0x03_Device Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0x03_Device jTNE_0X02_0X03 = new JTNE_0x02_0x03_Device();
            jTNE_0X02_0X03.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X03.FuelBatteryVoltage = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X03.FuelBatteryCurrent = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X03.FuelConsumptionRate = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X03.TemperatureProbeCount = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X03.Temperatures = JTNEBinaryExtensions.ReadBytesLittle(bytes, ref offset, jTNE_0X02_0X03.TemperatureProbeCount);
            jTNE_0X02_0X03.HydrogenSystemMaxTemp = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X03.HydrogenSystemMaxTempNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X03.HydrogenSystemMaxConcentrations = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X03.HydrogenSystemMaxConcentrationsNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X03.HydrogenSystemMaxPressure = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X03.HydrogenSystemMaxPressureNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X03.DCStatus = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNE_0X02_0X03;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0x03_Device value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.TypeCode);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.FuelBatteryVoltage);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.FuelBatteryCurrent);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.FuelConsumptionRate);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, (ushort)value.Temperatures.Length);
            offset += JTNEBinaryExtensions.WriteBytesLittle(bytes, offset, value.Temperatures);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.HydrogenSystemMaxTemp);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.HydrogenSystemMaxTempNo);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.HydrogenSystemMaxConcentrations);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.HydrogenSystemMaxConcentrationsNo);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.HydrogenSystemMaxPressure);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.HydrogenSystemMaxPressureNo);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.DCStatus);
            return offset;
        }
    }
}
