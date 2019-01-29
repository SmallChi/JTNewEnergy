using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 参数查询
    /// </summary>
    public abstract class  JTNE_0x81_Body
    {
        /// <summary>
        /// 车载终端本地存储时间周期，有效值范围：0~60 000（表示0ms~60 000ms）
        /// 最小计量单元：1ms
        /// 0xFF,0xFE表示异常，0xFF,0xFF表示无效
        /// </summary>
        public const byte JTNE_0x81_0x01_Type = 0x01;
        /// <summary>
        /// 正常时，信息上报时间周期，有效值范围：1~600（表示1s~600s）
        /// 最小计量单元：1s
        ///  0xFF,0xFE表示异常，0xFF,0xFF表示无效
        /// </summary>
        public const byte JTNE_0x81_0x02_Type = 0x02;
        /// <summary>
        /// 出现报警时，信息上报时间周期，有效值范围：0~60 000（表示0ms~60 000ms）
        ///  最小计量单元：1ms
        ///  0xFF,0xFE表示异常，0xFF,0xFF表示无效
        /// </summary>
        public const byte JTNE_0x81_0x03_Type = 0x03;
        /// <summary>
        /// 远程服务和管理平台域名长度M
        /// </summary>
        public const byte JTNE_0x81_0x04_Type = 0x04;
        /// <summary>
        /// 远程服务和管理平台域名
        /// </summary>
        public const byte JTNE_0x81_0x05_Type = 0x05;
        /// <summary>
        /// 远程服务和管理平台端口，有效值范围：0~65531
        ///  0xFF,0xFE表示异常，0xFF,0xFF表示无效
        /// </summary>
        public const byte JTNE_0x81_0x06_Type = 0x06;
        /// <summary>
        /// 硬件版本，车载终端厂商自行定义
        /// </summary>
        public const byte JTNE_0x81_0x07_Type = 0x07;
        /// <summary>
        /// 固件版本，车载终端厂商自行定义
        /// </summary>
        public const byte JTNE_0x81_0x08_Type = 0x08;
        /// <summary>
        /// 车载终端心跳发送周期，有效值范围：1~240（表示1s~240s）
        /// 最小计量单元：1s
        ///  0xFE表示异常，0xFF表示无效
        /// </summary>
        public const byte JTNE_0x81_0x09_Type = 0x09;
        /// <summary>
        /// 终端应答超时时间，有效值范围：1~600（表示1s~600s）
        /// 最小计量单元：1s
        ///   0xFF,0xFE表示异常，0xFF,0xFF表示无效
        /// </summary>
        public const byte JTNE_0x81_0x0A_Type = 0x0A;
        /// <summary>
        ///平台应答超时时间，有效值范围：1~600（表示1s~600s）
        /// 最小计量单元：1s
        ///   0xFF,0xFE表示异常，0xFF,0xFF表示无效
        /// </summary>
        public const byte JTNE_0x81_0x0B_Type = 0x0B;
        /// <summary>
        /// 连续三次登入失败后，到下一次登入的时间间隔。有效值范围：1~240（表示1min~240min）
        /// 最小计量单元：1min
        /// 0xFE表示异常，0xFF表示无效
        /// </summary>
        public const byte JTNE_0x81_0x0C_Type = 0x0C;
        /// <summary>
        /// 公共平台域名长度N
        /// </summary>
        public const byte JTNE_0x81_0x0D_Type = 0x0D;
        /// <summary>
        /// 公共平台域名
        /// </summary>
        public const byte JTNE_0x81_0x0E_Type = 0x0E;
        /// <summary>
        /// 公共平台端口，有效值访问：0~65531
        ///  0xFF,0xFE表示异常，0xFF,0xFF表示无效
        /// </summary>
        public const byte JTNE_0x81_0x0F_Type = 0x0F;
        /// <summary>
        /// 是否处于抽样监测中
        /// 0x01 表示是    0x02 表示否
        /// 0xFE表示异常，0xFF表示无效
        /// </summary>
        public const byte JTNE_0x81_0x10_Type = 0x10;

        internal static IDictionary<byte, Type> JTNE_0x81Method { get; private set; }
        /// <summary>
        /// A对象的长度，依赖于B对象的值 (数据长度为byte类型)
        /// </summary>
        internal static IDictionary<byte, byte> JTNE_0x81LengthOfADependOnValueOfB { get; private set; }
        /// <summary>
        /// 参数 ID
        /// </summary>
        public abstract byte ParamId { get; set; }

        /// <summary>
        /// 参数长度
        /// </summary>
        public abstract byte ParamLength { get; set; }

        static JTNE_0x81_Body()
        {
            JTNE_0x81Method = new Dictionary<byte, Type>();
            JTNE_0x81Method.Add(JTNE_0x81_0x01_Type, typeof(JTNE_0x81_0x01));
            JTNE_0x81Method.Add(JTNE_0x81_0x02_Type, typeof(JTNE_0x81_0x02));
            JTNE_0x81Method.Add(JTNE_0x81_0x03_Type, typeof(JTNE_0x81_0x03));
            JTNE_0x81Method.Add(JTNE_0x81_0x04_Type, typeof(JTNE_0x81_0x04));
            JTNE_0x81Method.Add(JTNE_0x81_0x05_Type, typeof(JTNE_0x81_0x05));
            JTNE_0x81Method.Add(JTNE_0x81_0x06_Type, typeof(JTNE_0x81_0x06));
            JTNE_0x81Method.Add(JTNE_0x81_0x07_Type, typeof(JTNE_0x81_0x07));
            JTNE_0x81Method.Add(JTNE_0x81_0x08_Type, typeof(JTNE_0x81_0x08));
            JTNE_0x81Method.Add(JTNE_0x81_0x09_Type, typeof(JTNE_0x81_0x09));
            JTNE_0x81Method.Add(JTNE_0x81_0x0A_Type, typeof(JTNE_0x81_0x0A));
            JTNE_0x81Method.Add(JTNE_0x81_0x0B_Type, typeof(JTNE_0x81_0x0B));
            JTNE_0x81Method.Add(JTNE_0x81_0x0C_Type, typeof(JTNE_0x81_0x0C));
            JTNE_0x81Method.Add(JTNE_0x81_0x0D_Type, typeof(JTNE_0x81_0x0D));
            JTNE_0x81Method.Add(JTNE_0x81_0x0E_Type, typeof(JTNE_0x81_0x0E));
            JTNE_0x81Method.Add(JTNE_0x81_0x0F_Type, typeof(JTNE_0x81_0x0F));
            JTNE_0x81Method.Add(JTNE_0x81_0x10_Type, typeof(JTNE_0x81_0x10));

            JTNE_0x81LengthOfADependOnValueOfB = new Dictionary<byte, byte>();
            JTNE_0x81LengthOfADependOnValueOfB.Add(JTNE_0x81_0x05_Type, JTNE_0x81_0x04_Type);
            JTNE_0x81LengthOfADependOnValueOfB.Add(JTNE_0x81_0x0E_Type, JTNE_0x81_0x0D_Type);
        }

        internal static void AddJTNE_0x81Method(byte paramId, Type type)
        {
            if (!JTNE_0x81Method.ContainsKey(paramId))
            {
                JTNE_0x81Method.Add(paramId, type);
            }
            else
            {
                JTNE_0x81Method[paramId] = type;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DependerParamId">依赖者</param>
        /// <param name="DependedParamId">被依赖者</param>
        internal static void AddJTNE_0x81LengthOfADependOnValueOfBMethod(byte DependerParamId, byte DependedParamId)
        {
            if (!JTNE_0x81LengthOfADependOnValueOfB.ContainsKey(DependerParamId))
            {
                JTNE_0x81LengthOfADependOnValueOfB.Add(DependerParamId, DependedParamId);
            }
            else
            {
                JTNE_0x81LengthOfADependOnValueOfB[DependerParamId] = DependedParamId;
            }
        }
    }
}
