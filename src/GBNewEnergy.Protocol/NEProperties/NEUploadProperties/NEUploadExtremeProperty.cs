using System;
using System.Collections.Generic;
using System.Text;
using GBNewEnergy.Protocol.Enums;

namespace GBNewEnergy.Protocol.NEProperties.NEUploadProperties
{
    /// <summary>
    /// 极值数据
    /// </summary>
    public class NEUploadExtremeProperty : NEUploadPropertyBase
    {
        public override NEInfoType NEInfoType => NEInfoType.极值数据;

        /// <summary>
        /// 最高电压电池总成号
        /// 有效值范围：1-250
        /// 异常：0XFE
        /// 无效：0xFF
        /// </summary>
        public byte MaxVoltageBatteryAssemblyNo { get; set; }
        /// <summary>
        /// 最高电压电池单体代号
        /// 有效值范围：1-250
        /// 异常：0XFE
        /// 无效：0xFF
        /// </summary>
        public byte MaxVoltageSingleBatteryNo { get; set; }
        /// <summary>
        /// 电池单体电压最高值
        /// 有效值范围：0-15000（表示0V - 15V）
        /// 最小计量单元：0.001V
        /// 异常：0xFF,0XFE
        /// 无效：0xFF,0xFF
        /// </summary>
        public double MaxVoltageSingleBatteryValue { get; set; }
        /// <summary>
        /// 最低电压电池子系统号
        /// 有效值范围：1-250
        /// 异常：0XFE
        /// 无效：0xFF
        /// </summary>
        public byte MinVoltageBatteryAssemblyNo { get; set; }
        /// <summary>
        /// 最低电压电池单体代号
        /// 有效值范围：1-250
        /// 异常：0XFE
        /// 无效：0xFF
        /// </summary>
        public byte MinVoltageSingleBatteryNo { get; set; }
        /// <summary>
        /// 最低单体电压最低值
        /// 有效值范围：0-15000（表示0V - 15V）
        /// 最小计量单元：0.001V
        /// 异常：0xFF,0XFE
        /// 无效：0xFF,0xFF
        /// </summary>
        public double MinVoltageSingleBatteryValue { get; set; }
        /// <summary>
        /// 蓄电池中最高温度子系统号
        /// 有效值范围：1-250
        /// 异常：0XFE
        /// 无效：0xFF
        /// </summary>
        public byte MaxTempProbeBatteryNo { get; set; }
        /// <summary>
        /// 蓄电池中最高温度探针序号
        /// 有效值范围：1-250
        /// 异常：0XFE
        /// 无效：0xFF
        /// </summary>
        public byte MaxTempBatteryAssemblyNo { get; set; }
        /// <summary>
        /// 最高温度值
        /// 有效值范围：0-250（数值偏移量40℃，表示-40℃ - +210℃）
        /// 最小计量单元：1℃
        /// 异常：0XFE
        /// 无效：0xFF
        /// </summary>
        public int MaxTempProbeBatteryValue { get; set; }
        /// <summary>
        /// 最低温度子系统号
        /// </summary>
        public byte MinTempProbeBatteryNo { get; set; }
        /// <summary>
        /// 蓄电池中最低温度探针序号
        /// </summary>
        public byte MinTempBatteryAssemblyNo { get; set; }
        /// <summary>
        /// 最低温度值
        /// </summary>
        public int MinTempProbeBatteryValue { get; set; }
    }
}
