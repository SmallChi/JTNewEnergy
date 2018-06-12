using GBNewEnergy.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.UpStream
{
    /// <summary>
    /// 通用应答
    /// </summary>
    public class CommonUpStream : NEBodies
    {
        public CommonUpStream(byte[] buffer, NEGlobalConfigs nEConfigs) : base(buffer, nEConfigs)
        {
        }

        public CommonUpStream(INEProperties nEProperties, NEGlobalConfigs nEConfigs) : base(nEProperties, nEConfigs)
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
