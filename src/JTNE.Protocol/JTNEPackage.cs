using System;
using System.IO;

namespace JTNE.Protocol
{
    /// <summary>
    /// 新能源包
    /// </summary>
    public class JTNEPackage
    {
        /// <summary>
        /// 固定为24个字节长度
        /// </summary>
        public const int HeaderFixedByteLength = 24;
        /// <summary>
        /// 起始符 
        /// 0x23
        /// </summary>
        public string BeginFlag { get; set; } = "##";
        /// <summary>
        /// 命令标识 
        /// </summary>
        public byte MsgId { get; set; }
        /// <summary>
        /// 应答标志 
        /// </summary>
        public byte AskId { get; set; }
        /// <summary>
        /// 车辆识别码
        /// </summary>
        public string VIN { get; set; }
        /// <summary>
        /// 数据加密方式 
        /// 0x01：数据不加密；0x02：数据经过 RSA 算法加密；0x03:数据经过 AES128 位算法加密；“0xFE”表示异常，“0xFF”表示无效
        /// </summary>
        public byte EncryptMethod { get; set; }
        /// <summary>
        /// 数据单元长度是数据单元的总字节数，有效值范围：0-65531
        /// </summary>
        public ushort DataUnitLength { get; set; }
        ///// <summary>
        ///// 数据体
        ///// </summary>
        //public NEBodies Bodies { get; protected set; }
        /// <summary>
        /// 采用BCC（异或检验）法，校验范围从命令单元的第一个字节开始，同后一个字节异或，直到校验码前一个字节为止，
        /// 校验码占用一个字节，当数据单元存在加密时，应先加密后检验，先校验后解密
        /// </summary>
        public byte BCCCode { get; set; }
    }
}
