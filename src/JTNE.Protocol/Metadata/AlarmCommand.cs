using JTNE.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Metadata
{
    /// <summary>
    /// 升级命令
    /// </summary>
    public class AlarmCommand
    {
        /// <summary>
        /// 报警等级
        /// </summary>
        public JTNEAlarmLevel AlarmLevel { get; set; }
        /// <summary>
        /// 报警信息
        /// </summary>
        public string  Alarm { get; set; }
    }
}
