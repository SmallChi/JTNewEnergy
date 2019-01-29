using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 参数查询响应
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x80Reply_Formatter))]
    public class JTNE_0x80Reply : JTNEBodies
    {
        /// <summary>
        /// 响应查询时间
        /// </summary>
        public DateTime ReplyTime { get; set; }
        /// <summary>
        /// 参数总数
        /// </summary>
        public byte ParamNum { get; set; }
        /// <summary>
        /// 参数列表
        /// </summary>
        public List<JTNE_0x80Reply_Body> ParamList { get; set; }
    }
}
