using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 平台登出
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x06_Platform_Formatter))]
    public class JTNE_0x06_Platform : JTNEBodies
    {
        /// <summary>
        /// 登出时间
        /// </summary>
        public DateTime LogoutTime { get; set; }
        /// <summary>
        /// 登出流水号与当次登入流水号一致
        /// </summary>
        public ushort LogoutNum { get; set; }
    }
}
