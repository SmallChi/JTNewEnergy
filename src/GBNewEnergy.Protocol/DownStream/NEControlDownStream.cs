using GBNewEnergy.Protocol.Extensions;
using GBNewEnergy.Protocol.NEProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.DownStream
{
    /// <summary>
    /// 车载终端控制命令
    /// </summary>
    public class NEControlDownStream : NEBodies
    {
        public NEControlDownStream(byte[] buffer, NEGlobalConfigs nEConfigs) : base(buffer, nEConfigs)
        {
        }

        public NEControlDownStream(INEProperties nEProperties, NEGlobalConfigs nEConfigs) : base(nEProperties, nEConfigs)
        {
        }

        /// <summary>
        /// 命令ID 只能发送一个
        /// </summary>
        public byte CmdId { get; set; }

        /// <summary>
        /// 命令参数
        /// [{id,value},{id,value}], 没有内容则内容为空
        /// </summary>
        public List<KeyValuePair<byte, string>> Vauels { get; set; }

        protected override void InitializeProperties(INEProperties nEProperties)
        {

        }

        protected override void InitializePropertiesFromBuffer()
        {
             CurrentDateTime = Buffer.ReadDateTimeLittle(0, 6);
        }

        protected override void ToBuffer()
        {
            Buffer = new byte[6];
            Buffer.WriteLittle(CurrentDateTime, 0, 6);
        }
    }
}
