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
    public class NEPackage:IBuffer
    {
        public NEPackage(byte[] header,byte[] body)
        {
            if (header[0] != BeginFlag && header[1] == BeginFlag) throw new NEException(ErrorCode.BeginFlagError, $"{header[0]},{header[1]}");
            MsgId = (MsgId)header[2];
            AskId = (AskId)header[3];
            VIN = Encoding.ASCII.GetString(header, 4, 17).Trim('\0');
            EncryptMethod = (EncryptMethod)header[21];
            DataUnitLength = header.ToIntH2L(22, 2);
            Header = header;
        }

        public NEPackage(string vin, MsgId msgId, AskId askId, NEBodies bodies,EncryptMethod encryptMethod)
        {
            MsgId = msgId;
            AskId = askId;
            VIN = vin;
            EncryptMethod = encryptMethod;
            Bodies = bodies;
            ToBuffer();
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
        /// 采用BCC（异或检验）法，校验范围从命令单元的第一个字节开始，同后一个字节异或，直到校验码前一个字节为止，
        /// 校验码占用一个字节，当数据单元存在加密时，应先加密后检验，先校验后解密
        /// </summary>
        public byte BCCCode { get; private set; }
        /// <summary>
        /// 头数据
        /// </summary>
        public byte[] Header { get; private set; }
        /// <summary>
        /// 数据体
        /// </summary>
        public NEBodies Bodies { get;protected set; }

        public byte[] Buffer { get; private set; }

        public override string ToString()
        {
            return this.Header.ToHexString()+" " +this.Buffer.ToHexString();
        }

        private void ToBuffer()
        {
            // 固定单元长度
            DataUnitLength = Bodies.Buffer.Length;
            Buffer = new byte[HeaderFixedByteLength + 1 + DataUnitLength];
            Buffer[0] = BeginFlag;
            Buffer[1] = BeginFlag;
            Buffer[2] = (byte)MsgId;
            Buffer[3] = (byte)AskId;
            Array.Copy(VIN.ToBytes(), 0, Buffer, 4, 20);
            Buffer[21] = (byte)EncryptMethod;
            Array.Copy(DataUnitLength.ToBytes(2), 0, Buffer, 22, 23);
            Array.Copy(Bodies.Buffer, 0, Buffer, 24, DataUnitLength);
            BCCCode = Buffer.ToXor(2, 23 + DataUnitLength);
            Buffer[HeaderFixedByteLength + DataUnitLength] = BCCCode;
            Array.Copy(Buffer,0, Header, 0, 22);
        }
    }
}
