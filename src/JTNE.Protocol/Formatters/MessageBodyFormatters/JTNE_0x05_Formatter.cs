using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x05_Formatter : IJTNEFormatter<JTNE_0x05>
    {
        public JTNE_0x05 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x05 jTNE_0X05 = new JTNE_0x05();
            jTNE_0X05.LoginTime = JTNEBinaryExtensions.ReadDateTime6Little(bytes, ref offset);
            jTNE_0X05.LoginNum = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X05.PlatformUserName = JTNEBinaryExtensions.ReadStringLittle(bytes, ref offset,12);
            jTNE_0X05.PlatformPassword = JTNEBinaryExtensions.ReadStringLittle(bytes, ref offset, 20);
            jTNE_0X05.EncryptMethod = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNE_0X05;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x05 value)
        {
            offset += JTNEBinaryExtensions.WriteDateTime6Little(bytes, offset, value.LoginTime);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.LoginNum);
            offset += JTNEBinaryExtensions.WriteStringLittle(bytes, offset, value.PlatformUserName,12);
            offset += JTNEBinaryExtensions.WriteStringLittle(bytes, offset, value.PlatformPassword, 20);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.EncryptMethod);
            return offset;
        }
    }
}
