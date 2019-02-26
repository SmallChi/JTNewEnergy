using System;
using System.Collections.Generic;
using System.Text;
using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 报警数据
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x02_0x07_Device_Formatter))]
    public class JTNE_0x02_0x07_Device : JTNE_0x02_Body_Device
    {
        public override byte TypeCode { get; set; } = JTNE_0x02_0x07_Device;

        /// <summary>
        /// 最高报警等级
        /// </summary>
        public byte AlarmLevel { get; set; }
        /// <summary>
        /// 通用报警标志
        /// </summary>
        public uint AlarmBatteryFlag { get; set; }
        /// <summary>
        /// 可充电储能装置故障总数
        /// </summary>
        public byte AlarmBatteryOtherCount { get; set; }
        /// <summary>
        /// 可充电储能装置故障代码列表
        /// </summary>
        public List<uint> AlarmBatteryOthers { get; set; }
        /// <summary>
        /// 驱动电机故障总数
        /// </summary>
        public byte AlarmElCount { get; set; }
        /// <summary>
        /// 驱动电机故障代码列表
        /// </summary>
        public List<uint> AlarmEls { get; set; }
        /// <summary>
        /// 发动机故障总数
        /// </summary>
        public byte AlarmEngineCount { get; set; }
        /// <summary>
        /// 发动机故障列表
        /// </summary>
        public List<uint> AlarmEngines { get; set; }
        /// <summary>
        /// 其他故障总数
        /// </summary>
        public byte AlarmOtherCount { get; set; }
        /// <summary>
        /// 其他故障代码列表
        /// </summary>
        public List<uint> AlarmOthers { get; set; }
    }
}
