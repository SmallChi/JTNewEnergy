using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Enums
{
    /// <summary>
    /// 应答标志
    /// </summary>
    public enum JTNEAskId:byte
    {
        /// <summary>
        /// 接收到的信息正确
        /// </summary>
        Success=0x01,
        /// <summary>
        /// 设置未成功
        /// </summary>
        Error=0x02,
        /// <summary>
        /// VIN重复错误
        /// </summary>
        VinRepeatError=0x03,
        /// <summary>
        /// 数据包为命令包，而非应答包
        /// </summary>
        CMD=0xFE
    }
}
