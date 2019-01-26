using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Metadata
{
    /// <summary>
    /// 电机信息
    /// </summary>
    public class Electrical
    {
        /// <summary>
        /// 驱动电机序号 
        /// </summary>
        public byte ElNo { get; set; }
        /// <summary>
        /// 驱动驱动电机状态
        /// </summary>
        public byte ElStatus { get; set; }
        /// <summary>
        /// 驱动电机控制器温度 
        /// </summary>
        public byte ElControlTemp { get; set; }
        /// <summary>
        /// 驱动电机转速
        /// </summary>
        public ushort ElSpeed { get; set; }
        /// <summary>
        /// 驱动电机转矩 
        /// </summary>
        public ushort ElTorque { get; set; }
        /// <summary>
        /// 驱动电机温度 
        /// </summary>
        public byte ElTemp { get; set; }
        /// <summary>
        /// 电机控制器输入电压 
        /// </summary>
        public ushort ElVoltage { get; set; }
        /// <summary>
        /// 电机控制器直接母线电流
        /// </summary>
        public ushort ElCurrent { get; set; }
    }
}
