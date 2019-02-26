using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x02_0x02_Device_Formatter : IJTNEFormatter<JTNE_0x02_0x02_Device>
    {
        public JTNE_0x02_0x02_Device Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0x02_Device jTNE_0X02_0X02 = new JTNE_0x02_0x02_Device();
            jTNE_0X02_0X02.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X02.ElectricalCount = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X02.Electricals = new List<Metadata.Electrical>();
            for (var i=0;i < jTNE_0X02_0X02.ElectricalCount; i++)
            {
                Metadata.Electrical electrical = new Metadata.Electrical();
                electrical.ElNo = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
                electrical.ElStatus = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
                electrical.ElControlTemp = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
                electrical.ElSpeed = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
                electrical.ElTorque = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
                electrical.ElTemp = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
                electrical.ElVoltage = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
                electrical.ElCurrent = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
                jTNE_0X02_0X02.Electricals.Add(electrical);
            }
            readSize = offset;
            return jTNE_0X02_0X02;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0x02_Device value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.TypeCode);
            if(value.Electricals!=null && value.Electricals.Count > 0)
            {
                offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.Electricals.Count);
                foreach(var item in value.Electricals)
                {
                    offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, item.ElNo);
                    offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, item.ElStatus);
                    offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, item.ElControlTemp);
                    offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, item.ElSpeed);
                    offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, item.ElTorque);
                    offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, item.ElTemp);
                    offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, item.ElVoltage);
                    offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, item.ElCurrent);
                }
            }
            return offset;
        }
    }
}
