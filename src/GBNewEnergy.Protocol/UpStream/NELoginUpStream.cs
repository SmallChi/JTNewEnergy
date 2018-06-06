using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.Request
{
    public class NELoginUpStream: NEBodies
    {
        protected NELoginUpStream(byte[] buffer) : base(buffer)
        {

        }

        /// <summary>
        /// SIM 卡号 
        /// </summary>
        public string SIM { get; set; }
        /// <summary>
        /// 电池总成数
        /// </summary>
        public byte BatteryCount { get; set; }
        /// <summary>
        /// 电池编码长度
        /// </summary>
        public byte BatteryLength { get; set; }
        /// <summary>
        /// 电池编码
        /// </summary>
        public IEnumerable<string> BatteryNos { get; set; }
    }
}
