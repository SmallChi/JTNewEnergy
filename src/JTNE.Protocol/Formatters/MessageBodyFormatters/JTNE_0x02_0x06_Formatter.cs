using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x02_0x06_Formatter : IJTNEFormatter<JTNE_0x02_0x06>
    {
        public JTNE_0x02_0x06 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0x06 jTNE_0X02_0X06 = new JTNE_0x02_0x06();
            jTNE_0X02_0X06.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06.MaxVoltageBatteryAssemblyNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06.MaxVoltageSingleBatteryNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06.MaxVoltageSingleBatteryValue = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X06.MinVoltageBatteryAssemblyNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06.MinVoltageSingleBatteryNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06.MinVoltageSingleBatteryValue = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X06.MaxTempProbeBatteryNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06.MaxTempBatteryAssemblyNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06.MaxTempProbeBatteryValue = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06.MinTempProbeBatteryNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06.MinTempBatteryAssemblyNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X06.MinTempProbeBatteryValue = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNE_0X02_0X06;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0x06 value)
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
