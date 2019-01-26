using System;
using System.Collections.Generic;
using System.Text;
using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using JTNE.Protocol.Metadata;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 可充电储能装置电压数据
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x02_0x08_Formatter))]
    public class JTNE_0x02_0x08 : JTNE_0x02_Body
    {
        public override byte TypeCode { get; set; } = JTNE_0x02_0x08;

        /// <summary>
        /// 可充电储能子系统个数
        /// </summary>
        public byte BatteryAssemblyCount { get; set; }
        /// <summary>
        /// 可充电储能子系统电压信息列表
        /// 每个可充电储能子系统电压信息长度
        /// </summary>
        public List<BatteryAssembly> BatteryAssemblies { get; set; }
    }
}
