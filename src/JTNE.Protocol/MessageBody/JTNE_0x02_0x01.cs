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
    [JTNEFormatter(typeof(JTNE_0x02_0x01_Formatter))]
    public class JTNE_0x02_0x01 : JTNE_0x02_Body
    {
        public override byte TypeCode { get; set; } = JTNE_0x02_0x01;

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
        /// <summary>
        /// 加速踏板行程值
        /// </summary>
        public byte Accelerator { get; set; }
        /// <summary>
        /// 制动踏板状态
        /// </summary>
        public byte Brakes { get; set; }
    }
}
