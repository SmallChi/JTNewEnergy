using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    ///  远程服务和管理平台域名长度M
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x81_0x04Formatter))]
    public class JTNE_0x81_0x04: JTNE_0x81_Body
    {
        public override byte ParamId { get; set; } = 0x04;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; } = 1;
        /// <summary>
        ///远程服务和管理平台域名长度M
        /// </summary>
        public byte ParamValue { get; set; }
    }
}
