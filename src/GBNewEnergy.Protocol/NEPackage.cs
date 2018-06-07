using GBNewEnergy.Protocol.Enums;
using GBNewEnergy.Protocol.Exceptions;
using GBNewEnergy.Protocol.Extensions;
using System;


namespace GBNewEnergy.Protocol
{
    /// <summary>
    /// 新能源包
    /// </summary>
    public class NEPackage:IBuffer
    {
        public NEPackage(byte[] header,byte[] body)
        {
            // 判断头部异常
            if (header[0] != BeginFlag && header[1] == BeginFlag) throw new NEException(ErrorCode.BeginFlagError, $"{header[0]},{header[1]}");
            // 组包
            byte[] packageBuffer = new byte[header.Length + body.Length];
            Array.Copy(header, 0, packageBuffer, 0, header.Length);
            Array.Copy(body, 0, packageBuffer, header.Length, body.Length);
            // 获取数据单元长度
            DataUnitLength = header.ReadUShortH2LLittle(22, 2);
            // 进行BCC校验码
            // 校验位=报文长度 - 最后一位（校验位） - 偏移量（2）
            int checkBit = packageBuffer.Length - 1 - 2;
            byte bCCCode = packageBuffer.ToXor(2, checkBit);
            byte bCCCode2 = body[body.Length - 1];
            if (bCCCode != bCCCode2) throw new NEException(ErrorCode.BCCCodeError, $"request:{bCCCode2}!=calculate:{bCCCode}");
            MsgId = (MsgId)header[2];
            AskId = (AskId)header[3];
            VIN = header.ReadStringLittle(4, 17);
            EncryptMethod = (EncryptMethod)header[21];
            // 通过命令id获取数据体
            Bodies = NEBodiesFactory.GetNEBodiesByMsgId(MsgId, body);
            Buffer = packageBuffer;
            Header = header;
        }

        public NEPackage(byte[] buf)
        {
            if (buf[0] != BeginFlag && buf[1] == BeginFlag) throw new NEException(ErrorCode.BeginFlagError, $"{buf[0]},{buf[1]}");
            MsgId = (MsgId)buf[2];
            AskId = (AskId)buf[3];
            VIN = buf.ReadStringLittle(4, 17);
            EncryptMethod = (EncryptMethod)buf[21];
            DataUnitLength = buf.ReadUShortH2LLittle(22, 2);
            // 进行BCC校验码
            // 校验位 = 报文长度 - 最后一位（校验位） - 偏移量（2）
            int checkBit = buf.Length - CheckBit - 2;
            byte bCCCode = buf.ToXor(2, checkBit);
            byte bCCCode2 = buf[buf.Length - CheckBit];
            if (bCCCode != bCCCode2)
            {
                throw new NEException(ErrorCode.BCCCodeError, $"request:{bCCCode2}!=calculate:{bCCCode}");
            }
            Bodies = NEBodiesFactory.GetNEBodiesByMsgId(MsgId, buf);
            Buffer = new byte[buf.Length + Bodies.Buffer.Length];
            Array.Copy(buf, 0, Buffer, 0, buf.Length);
            Array.Copy(Bodies.Buffer, 0, Buffer, buf.Length, Bodies.Buffer.Length);
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
        /// 校验位1字节
        /// </summary>
        private const int CheckBit = 1;
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

        private void ToBuffer()
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
            Buffer.WriteLittle(Bodies.Buffer, 24, DataUnitLength);
            BCCCode = Buffer.ToXor(2, (HeaderFixedByteLength + DataUnitLength - 1));
            Buffer[HeaderFixedByteLength + DataUnitLength] = BCCCode;
            Header = new byte[HeaderFixedByteLength];
            Array.Copy(Buffer, 0, Header, 0, HeaderFixedByteLength);
        }
    }
}
