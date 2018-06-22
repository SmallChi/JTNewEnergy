using System;
using System.Collections.Generic;
using System.Text;
using GBNewEnergy.Protocol.Enums;

namespace GBNewEnergy.Protocol.NEProperties.NEUploadProperties
{
    /// <summary>
    /// 报警数据
    /// </summary>
    public class NEUploadAlarmProperty : NEUploadPropertyBase
    {
        public override NEInfoType NEInfoType => NEInfoType.报警数据;

        /// <summary>
        /// 报警等级
        /// </summary>
        public byte AlarmLevel { get; set; }
        /// <summary>
        /// 通用报警标志
        /// </summary>
        public int AlarmBatteryFlag { get; set; }
        /// <summary>
        /// 报警没变化 0，有报警 1
        /// </summary>
        public byte AlarmBatteryChanged { get; set; }
        /// <summary>
        /// 可充电储能装置故障总数
        /// </summary>
        public byte AlarmBatteryOtherCount { get; set; }
        /// <summary>
        /// 可充电储能装置故障代码列表
        /// </summary>
        public List<int> AlarmBatteryOtherList { get; set; } = new List<int>();
        /// <summary>
        /// 驱动电机故障总数
        /// </summary>
        public byte AlarmElCount { get; set; }
        /// <summary>
        /// 驱动电机故障代码列表
        /// </summary>
        public List<int> AlarmElList { get; set; } = new List<int>();
        /// <summary>
        /// 发动机故障总数
        /// </summary>
        public byte AlarmEngineCount { get; set; }
        /// <summary>
        /// 发动机故障列表
        /// </summary>
        public List<int>AlarmEngineList { get; set; } = new List<int>();
        /// <summary>
        /// 其他故障总数
        /// </summary>
        public byte AlarmOtherCount { get; set; }
        /// <summary>
        /// 其他故障代码列表
        /// </summary>
        public List<int> AlarmOtherList { get; set; } = new List<int>();
    }
}
