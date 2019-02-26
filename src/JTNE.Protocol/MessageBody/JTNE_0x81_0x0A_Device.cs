using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 终端应答超时时间，有效值范围：1~600（表示1s~600s）
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x81_0x0A_Device_Formatter))]
    public class JTNE_0x81_0x0A_Device: JTNE_0x81_Body_Device
    {
        public override byte ParamId { get; set; } = 0x0A;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; } = 2;
        /// <summary>
        ///终端应答超时时间，有效值范围：1~600（表示1s~600s）
        /// </summary>
        public ushort ParamValue { get; set; }
    }
}
