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
    public enum JTNEMsgId:byte
    {
        /// <summary>
        /// 车辆登入
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x01))]
        login = 0x01,
        /// <summary>
        /// 实时信息上传
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x02))]
        uploadim = 0x02,
        /// <summary>
        /// 补传信息上传
        /// </summary>
        uploadsup = 0x03,
        /// <summary>
        /// 车辆登出
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x04))]
        loginout = 0x04,
        /// <summary>
        /// 平台登入
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x05))]
        platformlogin = 0x05,
        /// <summary>
        /// 平台登出
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x06))]
        platformlogout = 0x06,
        /// <summary>
        /// 心跳
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x07))]
        heartbeat = 0x07,
        /// <summary>
        /// 终端校时
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x08))]
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
