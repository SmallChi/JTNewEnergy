using GBNewEnergy.Protocol.Enums;
using GBNewEnergy.Protocol.Exceptions;
using GBNewEnergy.Protocol.Extensions;
using GBNewEnergy.Protocol.NEProperties;
using System;
using System.IO;

namespace GBNewEnergy.Protocol
{
    /// <summary>
    /// 新能源包
    /// </summary>
    public class NEPackage : NEBufferedEntityBase
    {
        public NEPackage(byte[] header, byte[] body, NEGlobalConfigs nEConfigs) : base(header, body, nEConfigs)
        {
        }

        public NEPackage(byte[] buf, NEGlobalConfigs nEConfigs) : base(buf, nEConfigs)
        {
        }

        public NEPackage(INEProperties nEProperties, NEGlobalConfigs nEConfigs)
            : base(nEProperties, nEConfigs)
        { }

        /// <summary>
        /// 固定为24个字节长度
        /// </summary>
        public const int HeaderFixedByteLength = 24;
        /// <summary>
        /// 起始符
        /// </summary>
        public const byte BeginFlag = 0x23;
        /// <summary>
        /// 校验位1字节
        /// </summary>
        private const int CheckBit = 1;
        /// <summary>
        /// 命令标识 
        /// </summary>
        public NEMsgId MsgId { get; private set; }
        /// <summary>
        /// 应答标志 
        /// </summary>
        public NEAskId AskId { get; private set; }
        /// <summary>
        /// 车辆识别码
        /// </summary>
        public string VIN { get; private set; }
        /// <summary>
        /// 数据加密方式 
        /// 0x01：数据不加密；0x02：数据经过 RSA 算法加密；0x03:数据经过 AES128 位算法加密；“0xFE”表示异常，“0xFF”表示无效
        /// </summary>
        public NEEncryptMethod EncryptMethod { get; private set; }
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
        public NEBodies Bodies { get; protected set; }

        protected override void ToBuffer()
        {
            // 固定单元长度
            DataUnitLength = Bodies.Buffer.Length;
            Buffer = new byte[HeaderFixedByteLength + DataUnitLength + CheckBit];
            Buffer[0] = BeginFlag;
            Buffer[1] = BeginFlag;
            Buffer[2] = (byte)MsgId;
            Buffer[3] = (byte)AskId;
            Buffer.WriteLittle(VIN, 4);
            Buffer[21] = (byte)EncryptMethod;
            Buffer.WriteLittle(DataUnitLength, 22, 2);
            if (NEConfigs.Encrypt != null)
            {
                Buffer.WriteLittle(NEConfigs.Encrypt.Encrypt(Bodies.Buffer), 24, DataUnitLength);
            }
            else
            {
                Buffer.WriteLittle(Bodies.Buffer, 24, DataUnitLength);
            }
            BCCCode = Buffer.ToXor(2, (HeaderFixedByteLength + DataUnitLength - 1));
            Buffer[HeaderFixedByteLength + DataUnitLength] = BCCCode;
            Header = new byte[HeaderFixedByteLength];
            Array.Copy(Buffer, 0, Header, 0, HeaderFixedByteLength);
        }

        protected override void InitializeProperties(INEProperties nEProperties)
        {
            NEPackageProperty nEPackageProperty = (NEPackageProperty)nEProperties;
            VIN = nEPackageProperty.VIN;
            MsgId = nEPackageProperty.MsgId;
            AskId = nEPackageProperty.AskId;
            Bodies = nEPackageProperty.Bodies;
            EncryptMethod = NEConfigs.EncryptMethod;
        }

        protected override void InitializePropertiesFromBuffer()
        {
            if (Buffer[0] != BeginFlag && Buffer[1] == BeginFlag) throw new NEException(NEErrorCode.BeginFlagError, $"{Buffer[0]},{Buffer[1]}");
            MsgId = (NEMsgId)Buffer[2];
            AskId = (NEAskId)Buffer[3];
            VIN = Buffer.ReadStringLittle(4, 17);
            EncryptMethod = (NEEncryptMethod)Buffer[21];
            DataUnitLength = Buffer.ReadUShortH2LLittle(22, 2);
            //  2.4. 验证校验码
            // 进行BCC校验码
            // 校验位 = 报文长度 - 最后一位（校验位） - 偏移量（2）
            int checkBit = Buffer.Length - CheckBit - 2;
            byte bCCCode = Buffer.ToXor(2, checkBit);
            byte bCCCode2 = Buffer[Buffer.Length - CheckBit];
            if (bCCCode != bCCCode2)
            {
                throw new NEException(NEErrorCode.BCCCodeError, $"request:{bCCCode2}!=calculate:{bCCCode}");
            }
            BCCCode = bCCCode2;
            byte[] bodiesBytes = new byte[DataUnitLength + CheckBit];
            Array.Copy(Buffer, HeaderFixedByteLength, bodiesBytes, 0, bodiesBytes.Length);
            if (NEConfigs.Encrypt != null)
            {
                Bodies = NEBodiesFactory.GetNEBodiesByMsgId(MsgId, NEConfigs.Encrypt.Decrypt(bodiesBytes),NEConfigs);
            }
            else
            {
                Bodies = NEBodiesFactory.GetNEBodiesByMsgId(MsgId, bodiesBytes, NEConfigs);
            }
            Header = new byte[HeaderFixedByteLength];
            Array.Copy(Buffer, 0, Header, 0, HeaderFixedByteLength);
        }
    }
}
