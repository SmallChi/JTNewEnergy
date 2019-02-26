using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    ///   是否处于抽样监测中 0x01 表示是    0x02 表示否
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x81_0x10_Device_Formatter))]
    public class JTNE_0x81_0x10_Device: JTNE_0x81_Body_Device
    {
        public override byte ParamId { get; set; } = 0x10;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; } = 1;
        /// <summary>
        /// 是否处于抽样监测中 0x01 表示是    0x02 表示否
        /// </summary>
        public byte ParamValue { get; set; }
    }
}
