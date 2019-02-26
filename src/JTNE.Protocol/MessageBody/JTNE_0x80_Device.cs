using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 参数查询
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x80_Device_Formatter))]
    public class JTNE_0x80_Device : JTNEBodies
    {
        /// <summary>
        /// 查询时间
        /// </summary>
        public DateTime QueryTime { get; set; }
        /// <summary>
        /// 参数总数
        /// </summary>
        public byte ParamNum { get; set; }
        /// <summary>
        /// 参数列表
        /// </summary>
        public byte[] ParamList { get; set; }
    }
}
