using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Enums
{
    /// <summary>
    /// 数据单元加密方式
    /// 0x01：数据不加密；0x02：数据经过 RSA 算法加密；0x03:数据经过 AES128 位算法加密；“0xFE”表示异常，“0xFF”表示无效
    /// </summary>
    public enum JTNEEncryptMethod:byte
    {
        /// <summary>
        /// 数据不加密
        /// </summary>
        None = 0x01,
        /// <summary>
        /// 数据经过 RSA 算法加密
        /// </summary>
        RSA = 0x02,
        /// <summary>
        /// 数据经过 AES128 位算法加密
        /// </summary>
        AES128 = 0x03,
        /// <summary>
        /// 表示异常
        /// </summary>
        Exception = 0xFE,
        /// <summary>
        /// 表示无效
        /// </summary>
        Invalid = 0xFF
    }
}
