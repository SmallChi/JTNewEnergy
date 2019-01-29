using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 终端控制
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x82_Formatter))]
    public class JTNE_0x82 : JTNEBodies
    {
        /// <summary>
        /// 控制时间
        /// </summary>
        public DateTime ControlTime { get; set; }
        /// <summary>
        /// 参数 
        /// </summary>
        public byte ParamID { get; set; }
        /// <summary>
        /// 参数 
        /// </summary>
        public JTNE_0x82_Body Parameter { get; set; }
    }
}
