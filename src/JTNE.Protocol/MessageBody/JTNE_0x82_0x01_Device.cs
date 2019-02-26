using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using JTNE.Protocol.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 远程升级：根据需要组合升级参数，参数之间用半角分号分割。
    /// 指令如下：“URL地址;拨号点名称;拨号用户名;拨号密码;地址;端口;生产厂商代码
    ///  ;硬件版本;固件版本;连接到升级服务器时限"
    ///   如某个参数无值，则为空
    ///   远程升级操作建议但不限于采用FTP方式进行操作，数据定义见表B.16
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x82_0x01_Device_Formatter))]
    public class JTNE_0x82_0x01_Device : JTNE_0x82_Body_Device
    {
        public override byte ParamId { get; set; } = 0x01;
        public override byte ParamLength { get; set; }
        public UpgradeCommand UpgradeCommand { get; set; }
    }
}
