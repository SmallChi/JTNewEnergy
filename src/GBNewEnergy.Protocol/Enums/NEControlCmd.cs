using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.Enums
{
    /// <summary>
    /// 车载终端控制命令枚举
    /// 0x80-0x7F 预留
    /// 0x80-0xFE 用户自定义
    /// </summary>
    public enum NEControlCmd:byte
    {
        /// <summary>
        /// 未用
        /// </summary>
        unused= 0x00,
        /// <summary>
        /// 远程升级  见表B.16
        /// </summary>
        remoteupdate = 0x01,
        /// <summary>
        /// 车载终端关机
        /// </summary>
        shutdown = 0x02,
        /// <summary>
        /// 车载终端复位
        /// </summary>
        reset = 0x03,
        /// <summary>
        /// 车载终端恢复出厂设置，其中包括本地存储时间周期、心跳发送时间周期、终端应答超时时间等等
        /// </summary>
        restorefactorysettings = 0x04,
        /// <summary>
        /// 断开数据通信链路
        /// </summary>
        interruptrequest = 0x05,
        /// <summary>
        /// 车载终端报警/预警，报警命令参数数据格式和定义见表B.17
        /// </summary>
        warning = 0x06,
        /// <summary>
        /// 开启抽样检测链路
        /// </summary>
        OpenMonitoring = 0x07,








    }
}
