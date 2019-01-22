using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol
{
    public abstract class NEBodies : NEBufferedEntityBase
    {
        /// <summary>
        /// VIN - 登入流水号,过期时间（每天置1）
        /// 车载终端登入一次，登入流水号自动加1，从1开始循环累加，最大值为65531，循环周期为天
        /// </summary>
        protected static readonly ConcurrentDictionary<string, LoginInfo> LoginNumDict;

        /// <summary>
        /// 平台登入 登录流水号,过期时间（每天置1）
        /// 下级平台登入一次，登入流水号自动加1，从1开始循环累加，最大值为65531，循环周期为天
        /// </summary>
        protected static readonly ConcurrentDictionary<string, PlatformLoginInfo> PlatformLoginNumDict;

        static NEBodies()
        {
            LoginNumDict = new ConcurrentDictionary<string, LoginInfo>();
            PlatformLoginNumDict = new ConcurrentDictionary<string, PlatformLoginInfo>();
        }

        /// <summary>
        /// 登入流水号
        /// 作用：看数据是否是连续请求
        /// </summary>
        public ushort LoginNum { get; set; }

        /// <summary>
        /// 数据采集时间
        /// 采用北京时间
        /// </summary>
        public DateTime CurrentDateTime { get; set; } = DateTime.Now;

        protected NEBodies(byte[] buffer, NEGlobalConfigs nEConfigs) : base(buffer, nEConfigs) { }

        protected NEBodies(INEProperties nEProperties, NEGlobalConfigs nEConfigs) : base(nEProperties, nEConfigs) { }

        protected class LoginInfo
        {
           public ushort LoginNum { get; set; }
           public DateTime ExpirationTime { get; set; }
        }

        protected class PlatformLoginInfo
        {
            public ushort LoginNum { get; set; }
            public DateTime ExpirationTime { get; set; }
        }
    }
}
