using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Metadata
{
    /// <summary>
    /// 每个可充电储能子系统温度信息
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
        public ushort TemperatureProbeCount { get; set; }
        /// <summary>
        /// 可充电储能子系统各温度探针检测到的温度值
        /// </summary>
        public byte[] Temperatures { get; set; }
    }
}
