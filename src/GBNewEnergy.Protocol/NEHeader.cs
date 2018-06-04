using GBNewEnergy.Protocol.Enums;
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
            if (buffer[0] != BeginFlag && buffer[1] == BeginFlag) throw new Exception("error");
            MsgId =(MsgId)buffer[2];
            AskId =(AskId)buffer[3];
            VIN = Encoding.ASCII.GetString(buffer, 4, 17).Trim('\0');
            EncryptMethod =(EncryptMethod)buffer[21];
            DataUnitLength = buffer.ToIntH2L(22, 2);
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
        /// <summary>
        /// 数据单元长度是数据单元的总字节数，有效值范围：0-65531
        /// </summary>
        public int DataUnitLength { get; private set; }
    }
}
