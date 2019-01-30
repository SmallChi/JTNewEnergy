using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 参数设置
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x81_Formatter))]
    public class JTNE_0x81 : JTNEBodies
    {
        /// <summary>
        /// 操作时间（若为设置操作时，则为设置时间，若为参数查询响应时，则为参数查询响应时间）
        /// </summary>
        public DateTime OperateTime { get; set; }
        /// <summary>
        /// 参数总数
        /// </summary>
        public byte ParamNum { get; set; } 
        /// <summary>
        /// 参数列表
        /// </summary>
        public List<JTNE_0x81_Body> ParamList { get; set; } 
    }
}
