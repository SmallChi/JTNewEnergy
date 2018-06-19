using System;
using System.Collections.Generic;
using System.Text;
using GBNewEnergy.Protocol.Enums;

namespace GBNewEnergy.Protocol.NEProperties.NEUploadProperties
{
    /// <summary>
    /// 燃料电池数据
    /// </summary>
    public class NEUploadFuelBatteryProperty : NEUploadPropertyBase
    {
        public override NEInfoType NEInfoType => NEInfoType.燃料电池数据;
        /// <summary>
        /// 燃料电池电压
        /// 有效值范围：0 - 20000（表示 0V-2000V）
        /// 最小计量单元：0.1V
        /// 异常：0xFF,0XFE
        /// 无效：0xFF,0xFF
        /// </summary>
        public double FuelBatteryVoltage { get; set; }
        /// <summary>
        /// 燃料电池电流
        /// 有效值范围：0 - 20000（表示 0A- +2000A）
        /// 最小计量单元：0.1 A
        /// 异常：0xFF,0XFE
        /// 无效：0xFF,0xFF
        /// </summary>
        public double FuelBatteryCurrent { get; set; }
        /// <summary>
        /// 燃料消耗率
        /// 有效值范围：0-60000（表示 0kg/100km - 600kg/100km）
        /// 最小计量单元：0.01kg/100km
        /// 异常：0xFF,0XFE
        /// 无效：0xFF,0xFF
        /// </summary>
        public double FuelConsumptionRate { get; set; }
        /// <summary>
        /// 燃料电池温度探针总数
        /// N个燃料电池温度探针
        /// 有效值范围：0-65531
        /// 异常：0xFF,0XFE
        /// 无效：0xFF,0xFF
        /// </summary>
        public int TemperatureProbeCount { get; set; }
        /// <summary>
        /// 探针温度值
        /// 有效值范围：0-240（数值偏移量40 ℃，表示-40 ℃ - +200 ℃）
        /// 最小计量单元：1 ℃
        /// </summary>
        public List<int> TemperatureList { get; set; } = new List<int>();
        /// <summary>
        /// 氢系统中最高温度
        /// 有效值范围：0-2400（偏移量40 ℃，表示-40 ℃ - 200 ℃）
        /// 最小计量单元：0.1 ℃
        /// 异常：0xFF,0XFE
        /// 无效：0xFF,0xFF
        /// </summary>
        public double HydrogenSystemMaxTemp { get; set; }
        /// <summary>
        /// 氢系统中最高温度探针代号
        /// 有效值范围：1-252
        /// 异常：0XFE
        /// 无效：0xFF
        /// </summary>
        public byte HydrogenSystemMaxTempNo { get; set; }
        /// <summary>
        /// 氢气最高浓度
        /// 有效值范围：0-60000（表示0 mg/kg - 50000 mg/kg）
        /// 最小计量单元：1 mg/kg
        /// 异常：0xFF,0XFE
        /// 无效：0xFF,0xFF
        /// </summary>
        public double HydrogenSystemMaxConcentrations { get; set; }
        /// <summary>
        /// 氢气最高浓度传感器代号
        /// 有效值范围：1-252
        /// 异常：0XFE
        /// 无效：0xFF
        /// </summary>
        public byte HydrogenSystemMaxConcentrationsNo { get; set; }
        /// <summary>
        /// 氢气最高压力
        /// 有效值范围：0-1000（表示0MPa - 100MPa）,最小计量单位：0.1MPa
        /// </summary>
        public double HydrogenSystemMaxPressure { get; set; }
        /// <summary>
        /// 氢气最高压力传感器代号
        /// 有效值访问:1-252
        /// 异常:0xFE
        /// 无效:0xFF
        /// </summary>
        public byte HydrogenSystemMaxPressureNo { get; set; }
        /// <summary>
        /// 高压DC/DC状态
        /// 0x01:工作
        /// 0x02:断开
        /// 0xFE:表示异常
        /// 0xFF:表示无效
        /// </summary>
        public byte DCStatus { get; set; }
    }
}
