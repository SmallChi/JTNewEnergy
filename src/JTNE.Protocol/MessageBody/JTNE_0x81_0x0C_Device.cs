using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    ///   连续三次登入失败后，到下一次登入的时间间隔。有效值范围：1~240（表示1min~240min）
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x81_0x0C_Device_Formatter))]
    public class JTNE_0x81_0x0C_Device: JTNE_0x81_Body_Device
    {
        public override byte ParamId { get; set; } = 0x0C;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; } = 1;
        /// <summary>
        ///  连续三次登入失败后，到下一次登入的时间间隔。有效值范围：1~240（表示1min~240min）
        /// </summary>
        public byte ParamValue { get; set; }
    }
}
