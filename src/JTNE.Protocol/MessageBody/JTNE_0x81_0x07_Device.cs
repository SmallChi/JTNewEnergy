using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 硬件版本，车载终端厂商自行定义
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x81_0x07_Device_Formatter))]
    public class JTNE_0x81_0x07_Device: JTNE_0x81_Body_Device
    {
        public override byte ParamId { get; set; } = 0x07;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; } = 5;
        /// <summary>
        ///硬件版本，车载终端厂商自行定义 数据长度= 5;
        /// </summary>
        public string ParamValue { get; set; }
    }
}
