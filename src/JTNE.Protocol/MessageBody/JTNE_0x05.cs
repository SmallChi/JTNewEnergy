using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 平台登入
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x05_Formatter))]
    public class JTNE_0x05 : JTNEBodies
    {
        /// <summary>
        /// 平台登入时间
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// 登入流水号
        /// 下级平台每登入一次，登入流水号自动加1，从1开始循环累加，最大值为65531，循环周期为天
        /// </summary>
        public ushort LoginNum { get; set; }
        /// <summary>
        /// 平台用户名
        /// </summary>
        public string PlatformUserName { get; set; }
        /// <summary>
        /// 平台密码
        /// </summary>
        public string PlatformPassword { get; set; }
        /// <summary>
        /// 数据加密方式 (默认不加密)
        /// 0x01：数据不加密；0x02：数据经过 RSA 算法加密；0x03:数据经过 AES128 位算法加密；“0xFE”表示异常，“0xFF”表示无效
        /// <see cref="JTNE.Protocol.Enums.JTNEEncryptMethod"/>
        /// </summary>
        public byte EncryptMethod { get; set; } = 0x01;
}
}
