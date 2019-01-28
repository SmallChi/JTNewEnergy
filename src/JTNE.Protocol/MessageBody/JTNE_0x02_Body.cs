using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    public abstract class JTNE_0x02_Body
    {
        /// <summary>
        /// 类型编码
        /// </summary>
        public abstract byte TypeCode { get; set; }

        /// <summary>
        /// 整车数据
        /// </summary>
        public const byte JTNE_0x02_0x01 = 0x01;
        /// <summary>
        /// 驱动电机数据
        /// </summary>
        public const byte JTNE_0x02_0x02 = 0x02;
        /// <summary>
        /// 燃料电池数据
        /// </summary>
        public const byte JTNE_0x02_0x03 = 0x03;
        /// <summary>
        /// 发动机数据
        /// </summary>
        public const byte JTNE_0x02_0x04 = 0x04;
        /// <summary>
        /// 车辆位置数据
        /// </summary>
        public const byte JTNE_0x02_0x05 = 0x05;
        /// <summary>
        /// 极值数据
        /// </summary>
        public const byte JTNE_0x02_0x06 = 0x06;
        /// <summary>
        /// 报警数据
        /// </summary>
        public const byte JTNE_0x02_0x07 = 0x07;
        /// <summary>
        /// 可充电储能装置电压数据
        /// </summary>
        public const byte JTNE_0x02_0x08 = 0x08;
        /// <summary>
        /// 可充电储能装置温度数据
        /// </summary>
        public const byte JTNE_0x02_0x09 = 0x09;

        static JTNE_0x02_Body()
        {
            TypeCodes = new Dictionary<byte, Type>();
            TypeCodes.Add(JTNE_0x02_0x01, typeof(JTNE_0x02_0x01));
            TypeCodes.Add(JTNE_0x02_0x02, typeof(JTNE_0x02_0x02));
            TypeCodes.Add(JTNE_0x02_0x03, typeof(JTNE_0x02_0x03));
            TypeCodes.Add(JTNE_0x02_0x04, typeof(JTNE_0x02_0x04));
            TypeCodes.Add(JTNE_0x02_0x05, typeof(JTNE_0x02_0x05));
            TypeCodes.Add(JTNE_0x02_0x06, typeof(JTNE_0x02_0x06));
            TypeCodes.Add(JTNE_0x02_0x07, typeof(JTNE_0x02_0x07));
            TypeCodes.Add(JTNE_0x02_0x08, typeof(JTNE_0x02_0x08));
            TypeCodes.Add(JTNE_0x02_0x09, typeof(JTNE_0x02_0x09));
        }

        internal static Dictionary<byte, Type> TypeCodes;


    }
}
