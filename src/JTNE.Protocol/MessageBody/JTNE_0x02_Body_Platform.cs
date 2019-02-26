using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    public abstract class JTNE_0x02_Body_Platform
    {
        /// <summary>
        /// 类型编码
        /// </summary>
        public abstract byte TypeCode { get; set; }

        /// <summary>
        /// 整车数据
        /// </summary>
        public const byte JTNE_0x02_0x01_Platform = 0x01;
        /// <summary>
        /// 驱动电机数据
        /// </summary>
        public const byte JTNE_0x02_0x02_Platform = 0x02;
        /// <summary>
        /// 燃料电池数据
        /// </summary>
        public const byte JTNE_0x02_0x03_Platform = 0x03;
        /// <summary>
        /// 发动机数据
        /// </summary>
        public const byte JTNE_0x02_0x04_Platform = 0x04;
        /// <summary>
        /// 车辆位置数据
        /// </summary>
        public const byte JTNE_0x02_0x05_Platform = 0x05;
        /// <summary>
        /// 极值数据
        /// </summary>
        public const byte JTNE_0x02_0x06_Platform = 0x06;
        /// <summary>
        /// 报警数据
        /// </summary>
        public const byte JTNE_0x02_0x07_Platform = 0x07;

        static JTNE_0x02_Body_Platform()
        {
            TypeCodes = new Dictionary<byte, Type>();
            TypeCodes.Add(JTNE_0x02_0x01_Platform, typeof(JTNE_0x02_0x01_Platform));
            TypeCodes.Add(JTNE_0x02_0x02_Platform, typeof(JTNE_0x02_0x02_Platform));
            TypeCodes.Add(JTNE_0x02_0x03_Platform, typeof(JTNE_0x02_0x03_Platform));
            TypeCodes.Add(JTNE_0x02_0x04_Platform, typeof(JTNE_0x02_0x04_Platform));
            TypeCodes.Add(JTNE_0x02_0x05_Platform, typeof(JTNE_0x02_0x05_Platform));
            TypeCodes.Add(JTNE_0x02_0x06_Platform, typeof(JTNE_0x02_0x06_Platform));
            TypeCodes.Add(JTNE_0x02_0x07_Platform, typeof(JTNE_0x02_0x07_Platform));
        }

        internal static Dictionary<byte, Type> TypeCodes;


    }
}
