using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 正常时，信息上报时间周期，有效值范围：1~600（表示1s~600s） 最小计量单元：1s
    /// 0x81_0x02
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x80Reply_0x02Formatter))]
    public class JTNE_0x80Reply_0x02: JTNE_0x80Reply_Body
    {
        public override byte ParamId { get; set; } = 0x02;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; } = 2;
        /// <summary>
        /// 正常时，信息上报时间周期，有效值范围：1~600（表示1s~600s） 最小计量单元：1s
        /// </summary>
        public ushort ParamValue { get; set; }
    }
}
