using GBNewEnergy.Protocol.Extensions;
using GBNewEnergy.Protocol.NEProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.DownStream
{
    /// <summary>
    /// 查询命令
    /// </summary>
    public class NEQueryDownStream : NEBodies
    {
        public NEQueryDownStream(byte[] buffer, NEGlobalConfigs nEConfigs) : base(buffer, nEConfigs)
        {
        }

        public NEQueryDownStream(INEProperties nEProperties, NEGlobalConfigs nEConfigs) : base(nEProperties, nEConfigs)
        {
        }

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
