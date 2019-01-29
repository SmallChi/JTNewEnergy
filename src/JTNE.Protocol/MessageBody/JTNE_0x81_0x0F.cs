using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 公共平台端口，有效值访问：0~65531
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x81_0x0FFormatter))]
    public class JTNE_0x81_0x0F: JTNE_0x81_Body
    {
        public override byte ParamId { get; set; } = 0x0F;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; } = 2;
        /// <summary>
        ///公共平台端口，有效值访问：0~65531
        /// </summary>
        public ushort ParamValue { get; set; }
    }
}
