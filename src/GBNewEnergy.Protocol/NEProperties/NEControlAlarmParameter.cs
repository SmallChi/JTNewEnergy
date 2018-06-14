using System;
using System.Collections.Generic;
using System.Text;
using GBNewEnergy.Protocol.Enums;

namespace GBNewEnergy.Protocol.NEProperties
{
    /// <summary>
    /// 控制命令 报警、预警
    /// </summary>
    public class NEControlAlarmParameter
    {
        /// <summary>
        /// 报警等级
        /// </summary>
        public NEAlarmLevel nEAlarmLevel { get; set; }
    }
}
