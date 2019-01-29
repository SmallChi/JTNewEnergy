using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 远程服务和管理平台端口，有效值范围：0~65531
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x80Reply_0x06Formatter))]
    public class JTNE_0x80Reply_0x06: JTNE_0x80Reply_Body
    {
        public override byte ParamId { get; set; } = 0x06;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; } = 2;
        /// <summary>
        ///远程服务和管理平台端口，有效值范围：0~65531
        /// </summary>
        public ushort ParamValue { get; set; }
    }
}
