using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x02_0x01_Platform_Formatter : IJTNEFormatter<JTNE_0x02_0x01_Platform>
    {
        public JTNE_0x02_0x01_Platform Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0x01_Platform jTNE_0X02_0X01_Platform = new JTNE_0x02_0x01_Platform();
            jTNE_0X02_0X01_Platform.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X01_Platform.CarStatus= JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X01_Platform.ChargeStatus = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X01_Platform.OperationMode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X01_Platform.Speed = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X01_Platform.TotalDis = JTNEBinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jTNE_0X02_0X01_Platform.TotalVoltage= JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X01_Platform.TotalTemp = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X01_Platform.SOC = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X01_Platform.DCStatus = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X01_Platform.Stall = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X01_Platform.Resistance = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            readSize = offset;
            return jTNE_0X02_0X01_Platform;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0x01_Platform value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.TypeCode);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.CarStatus);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.ChargeStatus);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.OperationMode);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.Speed);
            offset += JTNEBinaryExtensions.WriteUInt32Little(bytes, offset, value.TotalDis);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.TotalVoltage);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.TotalTemp);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.SOC);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.DCStatus);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.Stall);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.Resistance);
            return offset;
        }
    }
}
