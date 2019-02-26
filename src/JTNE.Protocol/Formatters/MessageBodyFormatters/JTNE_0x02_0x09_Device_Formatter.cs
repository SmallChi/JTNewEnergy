using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x02_0x09_Device_Formatter : IJTNEFormatter<JTNE_0x02_0x09_Device>
    {
        public JTNE_0x02_0x09_Device Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0x09_Device jTNE_0X02_0X09 = new JTNE_0x02_0x09_Device();
            jTNE_0X02_0X09.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X09.BatteryTemperatureCount = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X09.BatteryTemperatures = new List<Metadata.BatteryTemperature>();
            for(int i=0;i< jTNE_0X02_0X09.BatteryTemperatureCount; i++)
            {
                Metadata.BatteryTemperature batteryTemperature = new Metadata.BatteryTemperature();
                batteryTemperature.BatteryAssemblyNo= JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
                batteryTemperature.TemperatureProbeCount = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
                batteryTemperature.Temperatures = JTNEBinaryExtensions.ReadBytesLittle(bytes, ref offset, batteryTemperature.TemperatureProbeCount);
                jTNE_0X02_0X09.BatteryTemperatures.Add(batteryTemperature);
            }
            readSize = offset;
            return jTNE_0X02_0X09;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0x09_Device value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.TypeCode);
            if(value.BatteryTemperatures!=null && value.BatteryTemperatures.Count > 0)
            {
                offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.BatteryTemperatures.Count);
                foreach (var item in value.BatteryTemperatures)
                {
                    offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, item.BatteryAssemblyNo);
                    if(item.Temperatures!=null && item.Temperatures.Length > 0)
                    {
                        offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, (byte)item.Temperatures.Length);
                        offset += JTNEBinaryExtensions.WriteBytesLittle(bytes, offset, item.Temperatures);
                    }
                }
            }
            return offset;
        }
    }
}
