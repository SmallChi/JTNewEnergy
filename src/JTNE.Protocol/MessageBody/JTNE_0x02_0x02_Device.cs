using System;
using System.Collections.Generic;
using System.Text;
using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using JTNE.Protocol.Metadata;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 驱动电机数据
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x02_0x02_Device_Formatter))]
    public class JTNE_0x02_0x02_Device : JTNE_0x02_Body_Device
    {
        public override byte TypeCode { get; set; } = JTNE_0x02_0x02_Device;

        /// <summary>
        /// 电机个数
        /// </summary>
        public byte ElectricalCount { get; set; }

        /// <summary>
        /// 电机信息集合
        /// </summary>
        public List<Electrical> Electricals { get; set; }
    }
}
