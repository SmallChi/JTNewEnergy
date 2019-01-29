using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 固件版本，车载终端厂商自行定义
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x81_0x08Formatter))]
    public class JTNE_0x81_0x08: JTNE_0x81_Body
    {
        public override byte ParamId { get; set; } = 0x08;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; } = 5;
        /// <summary>
        ///固件版本，车载终端厂商自行定义
        /// </summary>
        public string ParamValue { get; set; }
    }
}
