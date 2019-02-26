using System;
using System.Collections.Generic;
using System.Text;
using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using JTNE.Protocol.Metadata;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 发动机数据
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x02_0x04_Device_Formatter))]
    public class JTNE_0x02_0x04_Device : JTNE_0x02_Body_Device
    {
        public override byte TypeCode { get; set; } = JTNE_0x02_0x04_Device;

        /// <summary>
        /// 发动机状态
        /// 0x01：启动状态
        /// 0x02：关闭状态
        /// 0xFE：异常
        /// 0xFF：无效
        /// </summary>
        public byte EngineStatus { get; set; }
        /// <summary>
        /// 曲轴转速
        /// 有效范围：0-60000（表示0 r/min-60000 r/min）
        /// 最小计量单元：1 r/min
        /// 异常：0xFF,0XFE
        /// 无效：0xFF,0xFF
        /// </summary>
        public ushort Revs { get; set; }
        /// <summary>
        /// 燃料消耗率
        /// 有效值范围：0-60000（表示0L/100km - 600L/100km）
        /// 最小计量单元：0.01L/km
        /// 异常：0xFF,0XFE
        /// 无效：0xFF,0xFF
        /// </summary>
        public ushort FuelRate { get; set; }
    }
}
