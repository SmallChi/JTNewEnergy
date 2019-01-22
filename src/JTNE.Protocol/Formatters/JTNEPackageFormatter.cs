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
            if (!JTNEGlobalConfigs.Instance.SkipCRCCode)
            {
                byte bCCCode = bytes[bytes.Length - 1];
                byte bCCCode2 = bytes.ToXor(2, bytes.Length - 1);
                if (bCCCode != bCCCode2)
                    throw new JTNEException(JTNEErrorCode.BCCCodeError, $"request:{bCCCode}!=calculate:{bCCCode2}");
            }
            JTNEPackage jTNEPackage = new JTNEPackage();
            offset += 2;
            // 3.命令标识
            jTNEPackage.MsgId = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            // 4.应答标识
            jTNEPackage.AskId = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            // 5.VIN
            jTNEPackage.VIN = JTNEBinaryExtensions.ReadStringLittle(bytes, ref offset,17);
            // 6.数据加密方式
            jTNEPackage.EncryptMethod = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            // 7.数据单元长度是数据单元的总字节数
            jTNEPackage.DataUnitLength = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            // 8.数据体
            // 8.1.根据数据加密方式进行解码
            // 8.2.解析出对应数据体
            jTNEPackage.Bodies = JTNEBinaryExtensions.ReadBytesLittle(bytes, ref offset, jTNEPackage.DataUnitLength);
            // 9.校验码
            jTNEPackage.BCCCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNEPackage;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNEPackage value)
        {
            // 1.起始符1
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.BeginFlag1);
            // 2.起始符2
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.BeginFlag2);
            // 3.命令标识
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.MsgId);
            // 4.应答标识
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.AskId);
            // 5.VIN
            offset += JTNEBinaryExtensions.WriteStringPadRightLittle(bytes, offset, value.VIN,17);
            // 6.数据加密方式
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.MsgId);
            // 7.数据单元长度是数据单元的总字节数 
            // 7.1.先解析出数据体
            // 7.2.判断是否有加密
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset,(ushort)value.Bodies.Length);
            // 8.数据体
            offset += JTNEBinaryExtensions.WriteBytesLittle(bytes, offset,value.Bodies);
            // 9.校验码
            var bccCode = bytes.ToXor(2, offset - 2);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, bccCode);
            return offset;
        }
    }
}
