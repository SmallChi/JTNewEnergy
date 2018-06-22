using System;
using System.Collections.Generic;
using System.Text;
using GBNewEnergy.Protocol.Enums;

namespace GBNewEnergy.Protocol.NEProperties.NEUploadProperties
{
    /// <summary>
    /// 驱动电机数据
    /// </summary>
    public class NEUploadDrivenElectricalProperty : NEUploadPropertyBase
    {
        public override NEInfoType NEInfoType => NEInfoType.驱动电机数据;

        /// <summary>
        /// 电机个数
        /// </summary>
        public byte ElectricalCount;
        /// <summary>
        /// 电机信息集合
        /// </summary>
        public IEnumerable<ElectricalInfo> ElectricalList { get; set; }

        /// <summary>
        /// 电机信息
        /// </summary>
        public class ElectricalInfo
        {
            /// <summary>
            /// 电机序号 
            /// </summary>
            public byte ElNo { get; set; }
            /// <summary>
            /// 电机状态
            /// </summary>
            public byte ElStatus { get; set; }
            /// <summary>
            /// 电机控制器温度 
            /// </summary>
            public int ElControlTemp { get; set; }
            /// <summary>
            /// 电机转速
            /// </summary>
            public int ElSpeed { get; set; }
            /// <summary>
            /// 电机转矩 
            /// </summary>
            public double ElTorque { get; set; }
            /// <summary>
            /// 电机温度 
            /// </summary>
            public int ElTemp { get; set; }
            /// <summary>
            /// 电机电压 
            /// </summary>
            public double ElVoltage { get; set; }
            /// <summary>
            /// 电机母线电流
            /// </summary>
            public double ElCurrent { get; set; }
        }
    }
}
