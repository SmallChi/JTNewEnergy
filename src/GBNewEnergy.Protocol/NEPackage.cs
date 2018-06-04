using GBNewEnergy.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol
{
    /// <summary>
    /// 新能源包
    /// </summary>
    public class NEPackage: BufferedEntityBase
    {
        public NEPackage(byte[] header,byte[] body):base(body)
        {
            this.NEHeader = new NEHeader(header);
            Array.Copy(header, 0, OriginalPackage, 0, header.Length);
            Array.Copy(body, 0, OriginalPackage, header.Length, body.Length);
        }
        /// <summary>
        /// 固定为24个字节长度
        /// </summary>
        public const int HeaderFixedByteLength = 24;
        /// <summary>
        /// 头部
        /// </summary>
        public NEHeader NEHeader { get; private set; }
        /// <summary>
        /// 数据单元
        /// </summary>
        public byte[] DataUnit { get; private set; }
        /// <summary>
        /// BCC 校验码
        /// </summary>
        public byte BCCCode { get; private set; }
        /// <summary>
        /// 原始包（包头+包体）
        /// </summary>
        public byte[] OriginalPackage { get; private set; }
    }
}
