using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x80_Device_Formatter : IJTNEFormatter<JTNE_0x80_Device>
    {
        public JTNE_0x80_Device Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x80_Device jTNE_0X80 = new JTNE_0x80_Device();
            jTNE_0X80.QueryTime = JTNEBinaryExtensions.ReadDateTime6Little(bytes, ref offset);
            jTNE_0X80.ParamNum = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X80.ParamList = JTNEBinaryExtensions.ReadBytesLittle(bytes, ref offset, jTNE_0X80.ParamNum);
            readSize = offset;
            return jTNE_0X80;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x80_Device value)
        {
            offset += JTNEBinaryExtensions.WriteDateTime6Little(bytes, offset, value.QueryTime);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.ParamNum);
            offset += JTNEBinaryExtensions.WriteBytesLittle(bytes, offset,value.ParamList);
            return offset;
        }
    }
}
