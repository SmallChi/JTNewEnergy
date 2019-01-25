using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x02_0x01_Formatter : IJTNEFormatter<JTNE_0x02_0x01>
    {
        public JTNE_0x02_0x01 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0x01 jTNE_0X02_0X01 = new JTNE_0x02_0x01();
            jTNE_0X02_0X01.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X01.CarStatus= JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X01.ChargeStatus = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X01.OperationMode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X01.Speed = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X01.TotalDis = JTNEBinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jTNE_0X02_0X01.TotalVoltage= JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X01.TotalTemp = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X01.SOC = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X01.DCStatus = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X01.Stall = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X01.Resistance = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0X01.Accelerator = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X01.Brakes = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNE_0X02_0X01;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0x01 value)
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
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.Accelerator);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.Brakes);
            return offset;
        }
    }
}
