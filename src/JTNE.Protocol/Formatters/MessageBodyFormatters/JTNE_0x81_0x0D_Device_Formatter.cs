using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x81_0x0D_Device_Formatter : IJTNEFormatter<JTNE_0x81_0x0D_Device>
    {
        public JTNE_0x81_0x0D_Device Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x81_0x0D_Device jTNE_0x81_0x0D_Device = new JTNE_0x81_0x0D_Device();
            jTNE_0x81_0x0D_Device.ParamValue = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNE_0x81_0x0D_Device;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x81_0x0D_Device value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.ParamValue);
            return offset;
        }
    }
}
