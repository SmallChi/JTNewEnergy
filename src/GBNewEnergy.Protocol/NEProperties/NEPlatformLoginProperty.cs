using GBNewEnergy.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.NEProperties
{
    public class NEPlatformLoginProperty : INEProperties
    {
        [Obsolete("平台登入无用字段")]
        public string VIN { get ; set; }
        /// <summary>
        /// 平台用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 加密规则
        /// </summary>
        public NEEncryptMethod EncryptMethod { get; set; }

        /// <summary>
        /// 平台密码
        /// </summary>
        public string Password { get; set; }
    }
}
