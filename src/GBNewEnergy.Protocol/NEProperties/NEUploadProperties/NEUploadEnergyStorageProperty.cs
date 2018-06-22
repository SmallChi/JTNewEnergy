using System;
using System.Collections.Generic;
using System.Text;
using GBNewEnergy.Protocol.Enums;

namespace GBNewEnergy.Protocol.NEProperties.NEUploadProperties
{
    /// <summary>
    /// 可充电储能装置电压数据
    /// </summary>
    public class NEUploadEnergyStorageProperty : NEUploadPropertyBase
    {
        public override NEInfoType NEInfoType => NEInfoType.可充电储能装置电压数据;

        /// <summary>
        /// 可充电储能子系统个数
        /// </summary>
        public byte BatteryAssemblyCount { get; set; }

        /// <summary>
        /// 可充电储能子系统电压信息列表
        /// </summary>
        public List<BatteryAssembly> BatteryAssemblyList { get; set; } = new List<BatteryAssembly>();

        /// <summary>
        /// 每个电池总成数据
        /// </summary>
        public class BatteryAssembly
        {
            /// <summary>
            /// 可充电储能子系统号
            /// </summary>
            public byte BatteryAssemblyNo { get; set; }
            /// <summary>
            /// 可充电储能装置电压
            /// </summary>
            public double BatteryAssemblyVoltage { get; set; }
            /// <summary>
            /// 可充电储能装置电流
            /// </summary>
            public double BatteryAssemblyCurrent { get; set; }
            /// <summary>
            /// 单体电池总数
            /// </summary>
            public int SingleBatteryCount { get; set; }
            /// <summary>
            /// 本帧起始电池序号
            /// </summary>
            public int ThisSingleBatteryBeginNo { get; set; }
            /// <summary>
            /// /本帧单体电池总数
            /// </summary>
            public int ThisSingleBatteryBeginCount { get; set; }
            /// <summary>
            /// 单体电池电压
            /// </summary>
            public List<double> SingleBatteryVoltageList { get; set; } = new List<double>();
        }
    }
}
