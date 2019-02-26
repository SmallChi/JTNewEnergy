using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 车载终端本地存储时间周期，有效值范围：0~60 000（表示0ms~60 000ms）最小计量单元：1ms
    /// 0x81_0x01
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x81_0x01_Device_Formatter))]
    public class JTNE_0x81_0x01_Device: JTNE_0x81_Body_Device
    {
        public override byte ParamId { get; set; } = 0x01;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; } = 2;
        /// <summary>
        /// 车载终端本地存储时间周期，（表示0ms~60 000ms）最小计量单元：1ms
        /// </summary>
        public ushort ParamValue { get; set; }
    }
}
