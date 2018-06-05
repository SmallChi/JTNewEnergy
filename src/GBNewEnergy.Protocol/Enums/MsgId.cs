using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.Enums
{
    /// <summary>
    /// 命令单元
    /// </summary>
    public enum MsgId:byte
    {
        /// <summary>
        /// 车辆登入
        /// </summary>
        login = 0x01,
        /// <summary>
        /// 实时信息上传
        /// </summary>
        uploadim = 0x02,
        /// <summary>
        /// 心跳
        /// </summary>
        heartbeat = 0x03,
        /// <summary>
        /// 补传信息上传
        /// </summary>
        uploadsup = 0x04,
        /// <summary>
        /// 车辆登出
        /// </summary>
        loginout = 0x05,
        /// <summary>
        /// 终端校时
        /// </summary>
        checktime = 0x08,
        /// <summary>
        /// 查询应答
        /// </summary>
        query = 0x80,
        /// <summary>
        /// 设置应答
        /// </summary>
        settings = 0x81,
        /// <summary>
        /// 控制应答
        /// </summary>
        control = 0x82
    }
}
