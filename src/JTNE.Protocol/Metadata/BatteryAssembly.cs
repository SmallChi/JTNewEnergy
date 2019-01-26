using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Metadata
{
    /// <summary>
    /// 每个可充电储能子系统电压信息
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
        public ushort BatteryAssemblyVoltage { get; set; }
        /// <summary>
        /// 可充电储能装置电流
        /// </summary>
        public ushort BatteryAssemblyCurrent { get; set; }
        /// <summary>
        /// 单体电池总数
        /// </summary>
        public ushort SingleBatteryCount { get; set; }
        /// <summary>
        /// 本帧起始电池序号
        /// </summary>
        public ushort ThisSingleBatteryBeginNo { get; set; }
        /// <summary>
        /// 本帧单体电池总数
        /// </summary>
        public byte ThisSingleBatteryBeginCount { get; set; }
        /// <summary>
        /// 单体电池电压
        /// </summary>
        public List<ushort> SingleBatteryVoltages { get; set; }
    }
}
