using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol
{
    public abstract class NEBodies : IBuffer, IBuffered
    {
        /// <summary>
        /// VIN - 登录流水号,过期时间（每天置1）
        /// 车载终端登入一次，登入流水号自动加1，从1开始循环累加，最大值为65531，循环周期为天
        /// </summary>
        protected static readonly ConcurrentDictionary<string, (ushort LoginNum, DateTime ExpirationTime)> LoginNumDict;

        static NEBodies()
        {
            LoginNumDict = new ConcurrentDictionary<string, (ushort LoginNum, DateTime ExpirationTime)>();
        }

        /// <summary>
        /// 登入流水号
        /// 作用：看数据是否是连续请求
        /// </summary>
        public ushort LoginNum { get; protected set; }

        /// <summary>
        /// 数据采集时间
        /// 采用北京时间
        /// </summary>
        public DateTime CurrentDateTime { get; protected set; }

        public byte[] Buffer { get; protected set; }

        protected NEBodies(byte[] buffer)
        {
            Buffer = buffer;
        }

        protected NEBodies(string vin)
        {
            CurrentDateTime = DateTime.Now;
        }

        public abstract void ToBuffer();
    }
}
