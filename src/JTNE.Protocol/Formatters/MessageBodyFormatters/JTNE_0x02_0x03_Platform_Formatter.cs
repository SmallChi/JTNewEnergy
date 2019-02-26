using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x02_0x03_Platform_Formatter : IJTNEFormatter<JTNE_0x02_0x03_Platform>
    {
        public JTNE_0x02_0x03_Platform Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0x03_Platform jTNE_0X02_0X03_Platform = new JTNE_0x02_0x03_Platform();
            jTNE_0X02_0X03_Platform.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X03_Platform.FuelBatteryVoltage = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X03_Platform.FuelBatteryCurrent = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X03_Platform.FuelConsumptionRate = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X03_Platform.TemperatureProbeCount = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X03_Platform.Temperatures = JTNEBinaryExtensions.ReadBytesLittle(bytes, ref offset, jTNE_0X02_0X03_Platform.TemperatureProbeCount);
            jTNE_0X02_0X03_Platform.HydrogenSystemMaxTemp = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X03_Platform.HydrogenSystemMaxTempNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X03_Platform.HydrogenSystemMaxConcentrations = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X03_Platform.HydrogenSystemMaxConcentrationsNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X03_Platform.HydrogenSystemMaxPressure = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X03_Platform.HydrogenSystemMaxPressureNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X03_Platform.DCStatus = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNE_0X02_0X03_Platform;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0x03_Platform value)
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
