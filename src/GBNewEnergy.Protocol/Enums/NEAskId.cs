using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.Enums
{
    /// <summary>
    /// 应答标志
    /// </summary>
    public enum NEAskId:byte
    {
        /// <summary>
        /// 接收到的信息正确
        /// </summary>
        success=0x01,
        /// <summary>
        /// 设置未成功
        /// </summary>
        error=0x02,
        /// <summary>
        /// VIN重复错误
        /// </summary>
        vin_repeat_error=0x03,
        /// <summary>
        /// 数据包为命令包，而非应答包
        /// </summary>
        cmd=0xFE
    }
}
