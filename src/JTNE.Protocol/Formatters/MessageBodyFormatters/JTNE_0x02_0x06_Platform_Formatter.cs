
using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x02_0x06_Platform_Formatter : IJTNEFormatter<JTNE_0x02_0x06_Platform>
    {
        public JTNE_0x02_0x06_Platform Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0x06_Platform jTNE_0X02_0X06_Platform = new JTNE_0x02_0x06_Platform();
            jTNE_0X02_0X06_Platform.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Platform.MaxVoltageBatteryAssemblyNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Platform.MaxVoltageSingleBatteryNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Platform.MaxVoltageSingleBatteryValue = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X06_Platform.MinVoltageBatteryAssemblyNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Platform.MinVoltageSingleBatteryNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Platform.MinVoltageSingleBatteryValue = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X06_Platform.MaxTempProbeBatteryNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Platform.MaxTempBatteryAssemblyNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Platform.MaxTempProbeBatteryValue = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Platform.MinTempProbeBatteryNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Platform.MinTempBatteryAssemblyNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06_Platform.MinTempProbeBatteryValue = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNE_0X02_0X06_Platform;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0x06_Platform value)
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
