using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 实时信息上报
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x02_Device_Formatter))]
    public class JTNE_0x02_Device : JTNEBodies
    {
        /// <summary>
        /// 公共值
        /// </summary>
        public Dictionary<byte, JTNE_0x02_Body_Device> Values { get; set; }
        /// <summary>
        /// 用于构造序列化自定义值
        /// </summary>
        public Dictionary<byte, JTNE_0x02_CustomBody_Device> CusotmSerializeObjectValues { get; set; }
        /// <summary>
        /// 自定义值
        /// </summary>
        public Dictionary<byte, byte[]> CusotmValues { get; set; }
    }
}
