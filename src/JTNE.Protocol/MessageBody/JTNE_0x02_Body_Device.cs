using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    public abstract class JTNE_0x02_Body_Device
    {
        /// <summary>
        /// 类型编码
        /// </summary>
        public abstract byte TypeCode { get; set; }

        /// <summary>
        /// 整车数据
        /// </summary>
        public const byte JTNE_0x02_0x01_Device = 0x01;
        /// <summary>
        /// 驱动电机数据
        /// </summary>
        public const byte JTNE_0x02_0x02_Device = 0x02;
        /// <summary>
        /// 燃料电池数据
        /// </summary>
        public const byte JTNE_0x02_0x03_Device = 0x03;
        /// <summary>
        /// 发动机数据
        /// </summary>
        public const byte JTNE_0x02_0x04_Device = 0x04;
        /// <summary>
        /// 车辆位置数据
        /// </summary>
        public const byte JTNE_0x02_0x05_Device = 0x05;
        /// <summary>
        /// 极值数据
        /// </summary>
        public const byte JTNE_0x02_0x06_Device = 0x06;
        /// <summary>
        /// 报警数据
        /// </summary>
        public const byte JTNE_0x02_0x07_Device = 0x07;
        /// <summary>
        /// 可充电储能装置电压数据
        /// </summary>
        public const byte JTNE_0x02_0x08_Device = 0x08;
        /// <summary>
        /// 可充电储能装置温度数据
        /// </summary>
        public const byte JTNE_0x02_0x09_Device = 0x09;

        static JTNE_0x02_Body_Device()
        {
            TypeCodes = new Dictionary<byte, Type>();
            TypeCodes.Add(JTNE_0x02_0x01_Device, typeof(JTNE_0x02_0x01_Device));
            TypeCodes.Add(JTNE_0x02_0x02_Device, typeof(JTNE_0x02_0x02_Device));
            TypeCodes.Add(JTNE_0x02_0x03_Device, typeof(JTNE_0x02_0x03_Device));
            TypeCodes.Add(JTNE_0x02_0x04_Device, typeof(JTNE_0x02_0x04_Device));
            TypeCodes.Add(JTNE_0x02_0x05_Device, typeof(JTNE_0x02_0x05_Device));
            TypeCodes.Add(JTNE_0x02_0x06_Device, typeof(JTNE_0x02_0x06_Device));
            TypeCodes.Add(JTNE_0x02_0x07_Device, typeof(JTNE_0x02_0x07_Device));
            TypeCodes.Add(JTNE_0x02_0x08_Device, typeof(JTNE_0x02_0x08_Device));
            TypeCodes.Add(JTNE_0x02_0x09_Device, typeof(JTNE_0x02_0x09_Device));
        }

        internal static Dictionary<byte, Type> TypeCodes;


    }
}
