using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.UpStream
{
    /// <summary>
    /// 实时信息上报
    /// </summary>
    public class NERealUploadUpStream : NEBodies
    {
        public NERealUploadUpStream(byte[] buffer, NEGlobalConfigs nEConfigs) : base(buffer, nEConfigs)
        {
        }

        public NERealUploadUpStream(INEProperties nEProperties, NEGlobalConfigs nEConfigs) : base(nEProperties, nEConfigs)
        {
        }

        protected override void InitializeProperties(INEProperties nEProperties)
        {
            throw new NotImplementedException();
        }

        protected override void InitializePropertiesFromBuffer()
        {
            throw new NotImplementedException();
        }

        protected override void ToBuffer()
        {
            throw new NotImplementedException();
        }
    }
}
