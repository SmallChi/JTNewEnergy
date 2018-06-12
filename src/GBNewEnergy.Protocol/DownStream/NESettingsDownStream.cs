using GBNewEnergy.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.DownStream
{
    /// <summary>
    /// 设置命令
    /// </summary>
    public class NESettingsDownStream : NEBodies
    {
        public NESettingsDownStream(byte[] buffer, NEGlobalConfigs nEConfigs) : base(buffer, nEConfigs)
        {
        }

        public NESettingsDownStream(INEProperties nEProperties, NEGlobalConfigs nEConfigs) : base(nEProperties, nEConfigs)
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
