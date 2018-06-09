using GBNewEnergy.Protocol.Exceptions;
using GBNewEnergy.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using GBNewEnergy.Protocol.NEProperties;

namespace GBNewEnergy.Protocol.UpStream
{
    /// <summary>
    /// 车辆登出
    /// </summary>
    public class NELogoutUpStream : NEBodies
    {
        public NELogoutUpStream(INEProperties nEProperties, NEGlobalConfigs nEConfigs) : base(nEProperties, nEConfigs)
        {
        }

        public NELogoutUpStream(byte[] buffer, NEGlobalConfigs nEConfigs) : base(buffer, nEConfigs)
        {
        }

        protected override void InitializeProperties(INEProperties nEProperties)
        {
            NELogoutProperty nELogoutProperty = (NELogoutProperty)nEProperties;
            LoginInfo temp;
            if (LoginNumDict.TryGetValue(nELogoutProperty.VIN, out temp))
            {
                LoginNum = temp.LoginNum;
            }
            else
            {
                throw new NEException(Enums.NEErrorCode.LoginSerialNoError, "Must Dependency NELoginUpStream Class.");
            }
        }

        protected override void InitializePropertiesFromBuffer()
        {
            CurrentDateTime = Buffer.ReadDateTimeLittle(0, 6);
            LoginNum = Buffer.ReadUShortH2LLittle(6, 2);
        }

        protected override void ToBuffer()
        {
            Buffer = new byte[8];
            Buffer.WriteLittle(CurrentDateTime, 0, 6);
            Buffer.WriteLittle(LoginNum, 6, 2);
        }
    }
}
