using GBNewEnergy.Protocol.Enums;
using GBNewEnergy.Protocol.Exceptions;
using GBNewEnergy.Protocol.Extensions;
using System;
using System.Text;

namespace GBNewEnergy.Protocol
{
    /// <summary>
    /// 头部
    /// </summary>
    public class NEHeader: BufferedEntityBase
    {
        public NEHeader(byte[] buffer):base(buffer)
        {
            
        }
        /// <summary>
        /// 起始符
        /// </summary>
        public const byte BeginFlag = 0x23;
        /// <summary>
        /// 命令标识 
        /// </summary>
        public MsgId MsgId { get; private set; }
        /// <summary>
        /// 应答标志 
        /// </summary>
        public AskId AskId { get; private set; }
        /// <summary>
        /// 车辆识别码
        /// </summary>
        public string VIN { get; private set; }
        /// <summary>
        /// 数据加密方式 
        /// 0x01：数据不加密；0x02：数据经过 RSA 算法加密；0x03:数据经过 AES128 位算法加密；“0xFE”表示异常，“0xFF”表示无效
        /// </summary>
        public EncryptMethod EncryptMethod { get; private set; }
    }
}
