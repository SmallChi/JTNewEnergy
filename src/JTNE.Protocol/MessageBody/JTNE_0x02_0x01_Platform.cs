using System;
using System.Collections.Generic;
using System.Text;
using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 整车数据
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x02_0x01_Platform_Formatter))]
    public class JTNE_0x02_0x01_Platform : JTNE_0x02_Body_Platform
    {
        public override byte TypeCode { get; set; } = JTNE_0x02_0x01_Platform;

        /// <summary>
        /// 车辆状态
        /// </summary>
        public byte CarStatus { get; set; }
        /// <summary>
        /// 充放电状态
        /// </summary>
        public byte ChargeStatus { get; set; }
        /// <summary>
        /// 运行模式
        /// </summary>
        public byte OperationMode { get; set; }
        /// <summary>
        /// 车速 
        /// </summary>
        public ushort Speed { get; set; }
        /// <summary>
        /// 累计里程
        /// </summary>
        public uint TotalDis { get; set; }
        /// <summary>
        /// 总电压 
        /// </summary>
        public ushort TotalVoltage { get; set; }
        /// <summary>
        /// 总电流 
        /// </summary>
        public ushort TotalTemp { get; set; }
        /// <summary>
        /// SOC 
        /// </summary>
        public byte SOC { get; set; }
        /// <summary>
        /// DC-DC 状态 
        /// </summary>
        public byte DCStatus { get; set; }
        /// <summary>
        /// 档位 
        /// </summary>
        public byte Stall { get; set; }
        /// <summary>
        /// 绝缘电阻
        /// </summary>
        public ushort Resistance { get; set; }
    }
}
