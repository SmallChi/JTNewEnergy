using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 车辆登入
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x01_Platform_Formatter))]
    public class JTNE_0x01_Platform : JTNEBodies
    {
        /// <summary>
        /// 数据采集时间
        /// 采用北京时间
        /// </summary>
        public DateTime PDATime { get; set; }
        /// <summary>
        /// 登入流水号
        /// 作用：看数据是否是连续请求
        /// </summary>
        public ushort LoginNum { get; set; }
        /// <summary>
        /// SIM卡ICCID号(ICCID应为终端从SIM卡获取的值,不应认为填写或修改)
        /// </summary>
        public string SIM { get; set; }
        /// <summary>
        /// 电池总成数
        /// 可充电储能子系统数
        /// </summary>
        public byte BatteryCount { get; set; }
        /// <summary>
        /// 电池编码长度
        /// 可充电储能系统编码长度
        /// </summary>
        public byte BatteryLength { get; set; }
        /// <summary>
        /// 电池编码
        /// 可充电储能系统编码
        /// </summary>
        public List<string> BatteryNos { get; set; }
    }
}
