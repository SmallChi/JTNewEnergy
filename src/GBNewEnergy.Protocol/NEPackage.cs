using GBNewEnergy.Protocol.Enums;
using GBNewEnergy.Protocol.Exceptions;
using GBNewEnergy.Protocol.Extensions;
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
            if (header[0] != BeginFlag && header[1] == BeginFlag) throw new NEException(ErrorCode.BeginFlagError, $"{header[0]},{header[1]}");
            MsgId = (MsgId)header[2];
            AskId = (AskId)header[3];
            VIN = Encoding.ASCII.GetString(header, 4, 17).Trim('\0');
            EncryptMethod = (EncryptMethod)header[21];
            DataUnitLength = header.ToIntH2L(22, 2);
            Header = header;
        }
        /// <summary>
        /// 固定为24个字节长度
        /// </summary>
        public const int HeaderFixedByteLength = 24;
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
        /// <summary>
        /// BCC校验码
        /// </summary>
        public byte BCCCode { get; private set; }
        /// <summary>
        /// 头数据
        /// </summary>
        public byte[] Header { get; private set; }

        public NEUpStreamBase NEUpStreamBase { get;protected set; }

        public override string ToString()
        {
            return Header.ToHexString()+" "+this.Buffer.ToHexString();
        }
    }
}
