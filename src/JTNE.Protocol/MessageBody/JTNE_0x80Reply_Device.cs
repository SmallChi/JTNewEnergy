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
    [JTNEFormatter(typeof(JTNE_0x80Reply_Device_Formatter))]
    public class JTNE_0x80Reply_Device : JTNEBodies
    {
        /// <summary>
        /// 
        /// </summary>
        public JTNE_0x81_Device JTNE_Reply0x80_Device { get; set; }
    }
}
