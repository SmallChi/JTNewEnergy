using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 公共平台域名
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x81_0x0EFormatter))]
    public class JTNE_0x81_0x0E: JTNE_0x81_Body
    {
        public override byte ParamId { get; set; } = 0x0E;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; }
        /// <summary>
        ///公共平台域名
        /// </summary>
        public byte[] ParamValue { get; set; }
    }
}
