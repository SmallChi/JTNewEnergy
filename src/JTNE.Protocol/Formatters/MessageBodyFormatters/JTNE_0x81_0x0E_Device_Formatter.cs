using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x81_0x0E_Device_Formatter : IJTNEFormatter<JTNE_0x81_0x0E_Device>
    {
        public JTNE_0x81_0x0E_Device Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x81_0x0E_Device jTNE_0x81_0x0E_Device = new JTNE_0x81_0x0E_Device();
            jTNE_0x81_0x0E_Device.ParamValue = JTNEBinaryExtensions.ReadBytesLittle(bytes, ref offset);
            jTNE_0x81_0x0E_Device.ParamLength = (byte)bytes.Length;
            readSize = offset;
            return jTNE_0x81_0x0E_Device;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x81_0x0E_Device value)
        {
            offset += JTNEBinaryExtensions.WriteBytesLittle(bytes, offset, value.ParamValue);
            return offset;
        }
    }
}
