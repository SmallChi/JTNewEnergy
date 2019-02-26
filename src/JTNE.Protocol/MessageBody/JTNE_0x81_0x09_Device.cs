using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    ///  车载终端心跳发送周期，有效值范围：1~240（表示1s~240s）
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x81_0x09_Device_Formatter))]
    public class JTNE_0x81_0x09_Device: JTNE_0x81_Body_Device
    {
        public override byte ParamId { get; set; } = 0x09;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; } = 1;
        /// <summary>
        /// 车载终端心跳发送周期，有效值范围：1~240（表示1s~240s）
        /// </summary>
        public byte ParamValue { get; set; }
    }
}
