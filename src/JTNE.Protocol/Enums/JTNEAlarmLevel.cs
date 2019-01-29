using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Enums
{
    /// <summary>
    /// 报警等级
    /// </summary>
    public enum JTNEAlarmLevel : byte
    {
        无报警 = 0x00,
        一级报警 = 0x01,
        二级报警 = 0x02,
        三级报警 = 0x03,
        无效数据 = 0xFF,
    }
}
