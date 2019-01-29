using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Metadata
{
    /// <summary>
    /// 升级命令
    /// </summary>
    public class UpgradeCommand
    {
        /// <summary>
        /// 拨号点名称
        /// 升级服务器的APN，无线通信拨号访问点
        /// 如果网络制式为CDMA，则该值为PPP连接拨号号码
        /// </summary>
        public string DialName { get; set; }
        /// <summary>
        /// 拨号用户名
        /// </summary>
        public string  DialUserName { get; set; }
        /// <summary>
        /// 拨号用户名
        /// </summary>
        public string DialUserPwd { get; set; }
        /// <summary>
        /// 升级服务器地址
        /// IP或域名 IPV4的前2个字节为0
        /// </summary>
        public byte[] ServerUrl { get; set; }
        /// <summary>
        /// 升级服务器端口
        /// </summary>
        public ushort ServerPort { get; set; }
        /// <summary>
        /// 车载终端制造商ID
        /// </summary>
        public string ManufacturerID { get; set; }
        /// <summary>
        /// 硬件版本
        /// </summary>
        public string HardwareVersion { get; set; }
        /// <summary>
        /// 固件版本
        /// </summary>
        public string FirmwareVersion { get; set; }
        /// <summary>
        /// 升级URL地址，完整URL地址
        /// 宜使用FTP协议，通过FTP协议从FTP服务器上获取新的软件
        /// </summary>
        public string ServerAddress { get; set; }
        /// <summary>
        /// 连接到升级服务器时限
        /// 有效值范围：0~60 000（表示0min~60 000min）最小计量单元：1min
        /// 在车载终端接收到升级命令后的有效期截止前，车载终端连回远程服务和管理平台
        /// </summary>
        public ushort ConnectTimeLimit { get; set; }

        public override string ToString()
        {
            return $"{ServerAddress};{DialName};{DialUserName};{DialUserPwd};{JTNEGlobalConfigs.Instance.Encoding.GetString(ServerUrl)};{ServerPort};{ManufacturerID};{HardwareVersion};{FirmwareVersion};{ConnectTimeLimit}";
        }
    }
}
