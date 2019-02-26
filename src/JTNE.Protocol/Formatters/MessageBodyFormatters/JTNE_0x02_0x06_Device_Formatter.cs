
using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x02_0x06_Device_Formatter : IJTNEFormatter<JTNE_0x02_0x06_Device>
    {
        public JTNE_0x02_0x06_Device Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0x06_Device jTNE_0X02_0X06_Device = new JTNE_0x02_0x06_Device();
            jTNE_0X02_0X06_Device.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Device.MaxVoltageBatteryAssemblyNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Device.MaxVoltageSingleBatteryNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Device.MaxVoltageSingleBatteryValue = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X06_Device.MinVoltageBatteryAssemblyNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Device.MinVoltageSingleBatteryNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Device.MinVoltageSingleBatteryValue = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X06_Device.MaxTempProbeBatteryNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Device.MaxTempBatteryAssemblyNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Device.MaxTempProbeBatteryValue = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Device.MinTempProbeBatteryNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Device.MinTempBatteryAssemblyNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Device.MinTempProbeBatteryValue = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNE_0X02_0X06_Device;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0x06_Device value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.TypeCode);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.MaxVoltageBatteryAssemblyNo);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.MaxVoltageSingleBatteryNo);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.MaxVoltageSingleBatteryValue);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.MinVoltageBatteryAssemblyNo);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.MinVoltageSingleBatteryNo);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.MinVoltageSingleBatteryValue);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.MaxTempProbeBatteryNo);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.MaxTempBatteryAssemblyNo);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.MaxTempProbeBatteryValue);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.MinTempProbeBatteryNo);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.MinTempBatteryAssemblyNo);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.MinTempProbeBatteryValue);
            return offset;
        }
    }
}
