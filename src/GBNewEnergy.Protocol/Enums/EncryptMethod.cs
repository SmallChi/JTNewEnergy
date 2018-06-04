using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.Enums
{
    /// <summary>
    /// 数据单元加密方式
    /// 0x01：数据不加密；0x02：数据经过 RSA 算法加密；0x03:数据经过 AES128 位算法加密；“0xFE”表示异常，“0xFF”表示无效
    /// </summary>
    public enum EncryptMethod:byte
    {
        None= 0x01,
        RSA= 0x02,
        AES128=0x03,
        Exception = 0xFE,
        Invalid= 0xFF
    }
}
