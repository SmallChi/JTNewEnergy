using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x06_Platform_Formatter : IJTNEFormatter<JTNE_0x06_Platform>
    {
        public JTNE_0x06_Platform Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x06_Platform jTNE_0X06_Platform = new JTNE_0x06_Platform();
            jTNE_0X06_Platform.LogoutTime = JTNEBinaryExtensions.ReadDateTime6Little(bytes, ref offset);
            jTNE_0X06_Platform.LogoutNum = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            readSize = offset;
            return jTNE_0X06_Platform;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x06_Platform value)
        {
            offset += JTNEBinaryExtensions.WriteDateTime6Little(bytes, offset, value.LogoutTime);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.LogoutNum);
            return offset;
        }
    }
}
