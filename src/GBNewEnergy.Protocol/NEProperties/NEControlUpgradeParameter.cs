using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.NEProperties
{
    /// <summary>
    /// 控制命令，升级
    /// </summary>
    public class NEControlUpgradeParameter
    {
        /// <summary>
        /// URL地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 拨号点名称
        /// </summary>
        public string DialPointName { get; set; }
        /// <summary>
        /// 拨号用户名
        /// </summary>
        public string DialUserName { get; set; }
        /// <summary>
        /// 拨号密码
        /// </summary>
        public string DialPassword { get; set; }
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string ServerUrl { get; set; }
        /// <summary>
        /// 服务器端口
        /// </summary>
        public string ServerPort { get; set; }
        /// <summary>
        /// 生产厂商代码
        /// </summary>
        public string ProviderCode { get; set; }
        /// <summary>
        /// 硬件版本
        /// </summary>
        public string HardwareVersion { get; set; }
        /// <summary>
        /// 固件版本
        /// </summary>
        public string FirmwareVersion { get; set; }
        /// <summary>
        /// 升级服务器时限
        /// </summary>
        public string UpLimitTime { get; set; }
        public override string ToString()
        {
            return $"{Url};{DialPointName};{DialUserName};{DialPassword};{ServerUrl};{ServerPort};{ProviderCode};{HardwareVersion};{FirmwareVersion};{UpLimitTime}";
        }
    }
}
