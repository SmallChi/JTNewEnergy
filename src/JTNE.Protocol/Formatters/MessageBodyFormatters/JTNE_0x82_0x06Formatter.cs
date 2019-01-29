using JTNE.Protocol.Enums;
using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x82_0x06Formatter : IJTNEFormatter<JTNE_0x82_0x06>
    {
        public JTNE_0x82_0x06 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x82_0x06 jTNE_0x82_0x06 = new JTNE_0x82_0x06();
            jTNE_0x82_0x06.AlarmCommand = new Metadata.AlarmCommand();
            jTNE_0x82_0x06.AlarmCommand.AlarmLevel= (JTNEAlarmLevel)JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);

            readSize = offset;
            return jTNE_0x82_0x06;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x82_0x06 value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.AlarmCommand.AlarmLevel.ToByteValue());
            //if (!string.IsNullOrEmpty(value.AlarmCommand.Alarm)) {
            //    offset += JTNEBinaryExtensions.WriteStringLittle(bytes, offset, value.AlarmCommand.Alarm);
            //}
            return offset;
        }
    }
}