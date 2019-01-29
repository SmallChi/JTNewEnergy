using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 出现报警时，信息上报时间周期，有效值范围：0~60 000（表示0ms~60 000ms）
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x81_0x03Formatter))]
    public class JTNE_0x81_0x03: JTNE_0x81_Body
    {
        public override byte ParamId { get; set; } = 0x03;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; } = 2;
        /// <summary>
        ///出现报警时，信息上报时间周期，有效值范围：0~60 000（表示0ms~60 000ms）
        /// </summary>
        public ushort ParamValue { get; set; }
    }
}
