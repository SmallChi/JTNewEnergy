using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x02_0x08_Device_Formatter : IJTNEFormatter<JTNE_0x02_0x08_Device>
    {
        public JTNE_0x02_0x08_Device Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0x08_Device jTNE_0X02_0X08 = new JTNE_0x02_0x08_Device();
            jTNE_0X02_0X08.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X08.BatteryAssemblyCount = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X08.BatteryAssemblies = new List<Metadata.BatteryAssembly>();
            for(int i=0;i< jTNE_0X02_0X08.BatteryAssemblyCount; i++)
            {
                Metadata.BatteryAssembly  batteryAssembly = new Metadata.BatteryAssembly();
                batteryAssembly.BatteryAssemblyNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
                batteryAssembly.BatteryAssemblyVoltage = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
                batteryAssembly.BatteryAssemblyCurrent = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
                batteryAssembly.SingleBatteryCount = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
                batteryAssembly.ThisSingleBatteryBeginNo = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
                batteryAssembly.ThisSingleBatteryBeginCount = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
                batteryAssembly.SingleBatteryVoltages = new List<ushort>();
                for(var j =0;j < batteryAssembly.ThisSingleBatteryBeginCount; j++)
                {
                    batteryAssembly.SingleBatteryVoltages.Add(JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset));
                }
                jTNE_0X02_0X08.BatteryAssemblies.Add(batteryAssembly);
            }
            readSize = offset;
            return jTNE_0X02_0X08;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0x08_Device value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.TypeCode);
            if (value.BatteryAssemblies!=null && value.BatteryAssemblies.Count > 0)
            {
                offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.BatteryAssemblies.Count);
                foreach (var item in value.BatteryAssemblies)
                {
                    offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, item.BatteryAssemblyNo);
                    offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, item.BatteryAssemblyVoltage);
                    offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, item.BatteryAssemblyCurrent);
                    offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, item.SingleBatteryCount);
                    offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, item.ThisSingleBatteryBeginNo);
                    if (item.SingleBatteryVoltages != null && item.SingleBatteryVoltages.Count > 0)
                    {
                        offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, (byte)item.SingleBatteryVoltages.Count);
                        foreach(var item1 in item.SingleBatteryVoltages)
                        {
                            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, item1);
                        }
                    }
                }
            }
            return offset;
        }
    }
}
