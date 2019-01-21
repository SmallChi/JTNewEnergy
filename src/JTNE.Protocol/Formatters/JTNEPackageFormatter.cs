using JTNE.Protocol.Enums;
using JTNE.Protocol.Exceptions;
using JTNE.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Formatters
{
    public class JTNEPackageFormatter : IJTNEFormatter<JTNEPackage>
    {
        public JTNEPackage Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            // 1.进行固定头校验
            if (bytes[offset] != JTNEPackage.BeginFlag && bytes[offset+1] == JTNEPackage.BeginFlag)
                throw new JTNEException(JTNEErrorCode.BeginFlagError, $"{bytes[offset]},{bytes[offset + 1]}");
            // 2.进行BCC校验码
            // 校验位 = 报文长度 - 最后一位（校验位）
            byte bCCCode = bytes[bytes.Length - 1];
            byte bCCCode2 = bytes.ToXor(2, bytes.Length - 1);
            if (bCCCode != bCCCode2)
                throw new JTNEException(JTNEErrorCode.BCCCodeError, $"request:{bCCCode}!=calculate:{bCCCode2}");
            JTNEPackage jTNEPackage = new JTNEPackage();
            offset += 2;
            jTNEPackage.MsgId = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNEPackage.AskId = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNEPackage.VIN = JTNEBinaryExtensions.ReadStringLittle(bytes, ref offset,17);
            jTNEPackage.EncryptMethod = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNEPackage.DataUnitLength = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            //todo:解码
            jTNEPackage.Bodies = JTNEBinaryExtensions.ReadBytesLittle(bytes, ref offset, jTNEPackage.DataUnitLength);
            jTNEPackage.BCCCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNEPackage;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNEPackage value)
        {
            throw new NotImplementedException();
        }
    }
}
