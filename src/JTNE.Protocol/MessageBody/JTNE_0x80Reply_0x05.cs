using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 远程服务和管理平台域名
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x80Reply_0x05Formatter))]
    public class JTNE_0x80Reply_0x05: JTNE_0x80Reply_Body
    {
        public override byte ParamId { get; set; } = 0x05;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; }
        /// <summary>
        ///远程服务和管理平台域名
        /// </summary>
        public byte[] ParamValue { get; set; }
    }
}
