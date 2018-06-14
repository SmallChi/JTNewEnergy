using System;
using System.Collections.Generic;
using System.Text;
using GBNewEnergy.Protocol.Enums;

namespace GBNewEnergy.Protocol.NEProperties
{
    /// <summary>
    /// 控制命令属性
    /// </summary>
    public class NEControlProperty : INEProperties
    {
        public string VIN { get; set ; }
        /// <summary>
        /// 命令ID 只能发送一个
        /// </summary>
        public NEControlCmd CmdID { get; set; }
        /// <summary>
        /// 升级参数
        /// </summary>
        public NEControlUpgradeParameter UpgradeParameter { get; set; }
        /// <summary>
        /// 报警，预警参数
        /// </summary>
        public NEControlAlarmParameter AlarmParameter { get; set; }
    }
}
