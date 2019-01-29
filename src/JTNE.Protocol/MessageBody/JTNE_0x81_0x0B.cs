using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 平台应答超时时间，有效值范围：1~600（表示1s~600s）
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x81_0x0BFormatter))]
    public class JTNE_0x81_0x0B: JTNE_0x81_Body
    {
        public override byte ParamId { get; set; } = 0x0B;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; } = 2;
        /// <summary>
        ///平台应答超时时间，有效值范围：1~600（表示1s~600s）
        /// </summary>
        public ushort ParamValue { get; set; }
    }
}
