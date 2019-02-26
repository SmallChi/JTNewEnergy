using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters;
using System;
using System.IO;

namespace JTNE.Protocol
{
    /// <summary>
    /// 新能源包
    /// </summary>
    [JTNEFormatter(typeof(JTNEPackage_DeviceFormatter))]
    public class JTNEPackage_Device
    {
        public const int FixedHeaderLength = 24;
        public const byte BeginFlag = 0x23;
        /// <summary>
        /// 起始符1
        /// </summary>
        public byte BeginFlag1 { get; set; } = BeginFlag;
        /// <summary>
        /// 起始符2 
        /// </summary>
        public byte BeginFlag2 { get; set; } = BeginFlag;
        /// <summary>
        /// 命令标识 
        /// <see cref="JTNE.Protocol.Enums.JTNEMsgId_Device"/>
        /// </summary>
        public byte MsgId { get; set; }
        /// <summary>
        /// 应答标志 
        /// <see cref="JTNE.Protocol.Enums.JTNEAskId"/>
        /// </summary>
        public byte AskId { get; set; }
        /// <summary>
        /// 车辆识别码
        /// </summary>
        public string VIN { get; set; }
        /// <summary>
        /// 数据加密方式 (默认不加密)
        /// 0x01：数据不加密；0x02：数据经过 RSA 算法加密；0x03:数据经过 AES128 位算法加密；“0xFE”表示异常，“0xFF”表示无效
        /// <see cref="JTNE.Protocol.Enums.JTNEEncryptMethod"/>
        /// </summary>
        public byte EncryptMethod { get; set; } = 0x01;
        /// <summary>
        /// 数据单元长度是数据单元的总字节数，有效值范围：0-65531
        /// </summary>
        public ushort DataUnitLength { get; set; }
        /// <summary>
        /// 数据体
        /// </summary>
        public JTNEBodies Bodies { get; set; }
        /// <summary>
        /// 采用BCC（异或检验）法，校验范围从命令单元的第一个字节开始，同后一个字节异或，直到校验码前一个字节为止，
        /// 校验码占用一个字节，当数据单元存在加密时，应先加密后检验，先校验后解密
        /// </summary>
        public byte BCCCode { get; set; }
    }
}
