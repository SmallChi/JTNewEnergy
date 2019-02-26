using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x02_0x07_Platform_Formatter : IJTNEFormatter<JTNE_0x02_0x07_Platform>
    {
        public JTNE_0x02_0x07_Platform Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0x07_Platform jTNE_0X02_0X07 = new JTNE_0x02_0x07_Platform();
            jTNE_0X02_0X07.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X07.AlarmLevel = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X07.AlarmBatteryFlag = JTNEBinaryExtensions.ReadUInt32Little(bytes, ref offset);

            jTNE_0X02_0X07.AlarmBatteryOtherCount = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X07.AlarmBatteryOthers = new List<uint>();
            for(int i=0;i< jTNE_0X02_0X07.AlarmBatteryOtherCount; i++)
            {
                jTNE_0X02_0X07.AlarmBatteryOthers.Add(JTNEBinaryExtensions.ReadUInt32Little(bytes, ref offset));
            }

            jTNE_0X02_0X07.AlarmElCount = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X07.AlarmEls = new List<uint>();
            for (int i = 0; i < jTNE_0X02_0X07.AlarmElCount; i++)
            {
                jTNE_0X02_0X07.AlarmEls.Add(JTNEBinaryExtensions.ReadUInt32Little(bytes, ref offset));
            }

            jTNE_0X02_0X07.AlarmEngineCount = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X07.AlarmEngines = new List<uint>();
            for (int i = 0; i < jTNE_0X02_0X07.AlarmEngineCount; i++)
            {
                jTNE_0X02_0X07.AlarmEngines.Add(JTNEBinaryExtensions.ReadUInt32Little(bytes, ref offset));
            }

            jTNE_0X02_0X07.AlarmOtherCount = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0X07.AlarmOthers = new List<uint>();
            for (int i = 0; i < jTNE_0X02_0X07.AlarmOtherCount; i++)
            {
                jTNE_0X02_0X07.AlarmOthers.Add(JTNEBinaryExtensions.ReadUInt32Little(bytes, ref offset));
            }

            readSize = offset;
            return jTNE_0X02_0X07;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0x07_Platform value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.TypeCode);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.AlarmLevel);
            offset += JTNEBinaryExtensions.WriteUInt32Little(bytes, offset, value.AlarmBatteryFlag);

            if(value.AlarmBatteryOthers!=null && value.AlarmBatteryOthers.Count > 0)
            {
                offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.AlarmBatteryOthers.Count);
                foreach (var item in value.AlarmBatteryOthers)
                {
                    offset += JTNEBinaryExtensions.WriteUInt32Little(bytes, offset, item);
                }
            }

            if (value.AlarmEls != null && value.AlarmEls.Count > 0)
            {
                offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.AlarmEls.Count);
                foreach (var item in value.AlarmEls)
                {
                    offset += JTNEBinaryExtensions.WriteUInt32Little(bytes, offset, item);
                }
            }

            if (value.AlarmEngines != null && value.AlarmEngines.Count > 0)
            {
                offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.AlarmEngines.Count);
                foreach (var item in value.AlarmEngines)
                {
                    offset += JTNEBinaryExtensions.WriteUInt32Little(bytes, offset, item);
                }
            }

            if (value.AlarmEngines != null && value.AlarmEngines.Count > 0)
            {
                offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.AlarmOthers.Count);
                foreach (var item in value.AlarmOthers)
                {
                    offset += JTNEBinaryExtensions.WriteUInt32Little(bytes, offset, item);
                }
            }
            return offset;
        }
    }
}
