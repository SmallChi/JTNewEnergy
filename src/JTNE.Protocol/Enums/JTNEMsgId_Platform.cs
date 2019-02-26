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
    public enum JTNEMsgId_Platform:byte
    {
        /// <summary>
        /// 车辆登入
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x01_Platform))]
        login = 0x01,
        /// <summary>
        /// 实时信息上传
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x02_Platform))]
        uploadim = 0x02,
        /// <summary>
        /// 补传信息上传
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x03_Platform))]
        uploadsup = 0x03,
        /// <summary>
        /// 车辆登出
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x04_Platform))]
        loginout = 0x04,
        /// <summary>
        /// 平台登入
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x05_Platform))]
        platformlogin = 0x05,
        /// <summary>
        /// 平台登出
        /// </summary>
        [JTNEBodiesType(typeof(JTNE_0x06_Platform))]
        platformlogout = 0x06,    
    }
}
