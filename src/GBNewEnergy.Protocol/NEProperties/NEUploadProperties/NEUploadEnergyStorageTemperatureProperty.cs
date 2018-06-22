using System;
using System.Collections.Generic;
using System.Text;
using GBNewEnergy.Protocol.Enums;

namespace GBNewEnergy.Protocol.NEProperties.NEUploadProperties
{
    /// <summary>
    /// 可充电储能装置温度数据
    /// </summary>
    public class NEUploadEnergyStorageTemperatureProperty : NEUploadPropertyBase
    {
        public override NEInfoType NEInfoType => NEInfoType.可充电储能装置温度数据;

        /// <summary>
        /// 动力蓄电池总成个数
        /// </summary>
        public byte BatteryAssemblyCount { get; set; }
        /// <summary>
        /// 每个可充电储能子系统温度信息长度
        /// </summary>
        public List<BatteryTemperature> BatteryAssemblyList { get; set; } = new List<BatteryTemperature>();

        /// <summary>
        /// 每个动力蓄电池上温度数据
        /// </summary>
        public class BatteryTemperature
        {
            /// <summary>
            /// 可充电储能子系统号
            /// </summary>
            public byte BatteryAssemblyNo { get; set; }
            /// <summary>
            /// 可充电储能温度探针个数
            /// </summary>
            public int TemperatureProbeCount { get; set; }
            /// <summary>
            /// 可充电储能子系统各温度探针检测到的温度值
            /// </summary>
            public List<int> TemperatureList { get; set; } = new List<int>();
        }
    }
}
