using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.NEProperties
{
    public class NEPlatformLogoutProperty : INEProperties
    {
        [Obsolete("平台登入无用字段")]
        public string VIN { get; set; }
        /// <summary>
        /// 平台用户名
        /// </summary>
        public string UserName { get; set; }
    }
}
