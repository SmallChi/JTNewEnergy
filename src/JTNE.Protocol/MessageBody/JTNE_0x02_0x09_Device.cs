using System;
using System.Collections.Generic;
using System.Text;
using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using JTNE.Protocol.Metadata;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 可充电储能装置温度数据
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x02_0x09_Device_Formatter))]
    public class JTNE_0x02_0x09_Device : JTNE_0x02_Body_Device
    {
        public override byte TypeCode { get; set; } = JTNE_0x02_0x09_Device;

        /// <summary>
        /// 可充电储能子系统个数
        /// </summary>
        public byte BatteryTemperatureCount { get; set; }
        /// <summary>
        /// 可充电储能子系统温度信息列表
        /// 每个可充电储能子系统温度信息长度
        /// </summary>
        public List<BatteryTemperature> BatteryTemperatures { get; set; }
    }
}
