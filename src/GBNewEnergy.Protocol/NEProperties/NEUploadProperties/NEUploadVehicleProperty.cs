using System;
using System.Collections.Generic;
using System.Text;
using GBNewEnergy.Protocol.Enums;

namespace GBNewEnergy.Protocol.NEProperties.NEUploadProperties
{ 
    /// <summary>
    /// 整车数据
    /// </summary>
    public class NEUploadVehicleProperty : NEUploadPropertyBase
    {
        public override NEInfoType NEInfoType => NEInfoType.整车数据;

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
        public double Speed { get; set; }
        /// <summary>
        /// 当前里程
        /// </summary>
        public double Dis { get; set; }
        /// <summary>
        /// 总里程
        /// </summary>
        public double TotalDis { get; set; }
        /// <summary>
        /// 总电压 
        /// </summary>
        public double TotalVoltage { get; set; }
        /// <summary>
        /// 总电流 
        /// </summary>
        public double TotalTemp { get; set; }
        /// <summary>
        /// SOC 
        /// </summary>
        public byte soc { get; set; }
        /// <summary>
        /// DC-DC 状态 
        /// </summary>
        public byte DCStatus { get; set; }
        /// <summary>
        /// 档位 
        /// </summary>
        public byte Stall { get; set; }
        /// <summary>
        /// 加速踏板行程值
        /// </summary>
        public byte Accelerator { get; set; }
        /// <summary>
        /// 制动踏板状态
        /// </summary>
        public byte Brakes { get; set; }
        /// <summary>
        /// 绝缘电阻
        /// </summary>
        public int Resistance { get; set; }
    }
}
