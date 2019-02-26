using JTNE.Protocol.Attributes;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Enums
{
    /// <summary>
    /// 命令单元
    /// </summary>
    public enum JTNEMsgId_Device:byte
    {
        /// <summary>
        /// 车辆登入
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x01_Device))]
        login = 0x01,
        /// <summary>
        /// 实时信息上传
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x02_Device))]
        uploadim = 0x02,
        /// <summary>
        /// 补传信息上传
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x03_Device))]
        uploadsup = 0x03,
        /// <summary>
        /// 车辆登出
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x04_Device))]
        loginout = 0x04,
        /// <summary>
        /// 心跳
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x07_Device))]
        heartbeat = 0x07,
        /// <summary>
        /// 终端校时
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x08_Device))]
        checktime = 0x08,
        /// <summary>
        /// 查询命令
        /// </summary>
        query = 0x80,
        /// <summary>
        /// 设置命令
        /// </summary>
        settings = 0x81,
        /// <summary>
        /// 控制命令
        /// </summary>
        control = 0x82
    }
}
