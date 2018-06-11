using GBNewEnergy.Protocol.Exceptions;
using GBNewEnergy.Protocol.Extensions;
using GBNewEnergy.Protocol.NEProperties;

namespace GBNewEnergy.Protocol.UpStream
{
    /// <summary>
    /// 平台登出
    /// </summary>
    public class NEPlatformLogoutUpStream : NEBodies
    {
        public NEPlatformLogoutUpStream(INEProperties nEProperties, NEGlobalConfigs nEConfigs) : base(nEProperties, nEConfigs)
        {
        }

        public NEPlatformLogoutUpStream(byte[] buffer, NEGlobalConfigs nEConfigs) : base(buffer, nEConfigs)
        {
        }

        protected override void InitializeProperties(INEProperties nEProperties)
        {
            NEPlatformLogoutProperty nEPlatformLogoutProperty = (NEPlatformLogoutProperty)nEProperties;
            PlatformLoginInfo temp;
            if (PlatformLoginNumDict.TryGetValue(nEPlatformLogoutProperty.UserName, out temp))
            {
                LoginNum = temp.LoginNum;
            }
            else
            {
                throw new NEException(Enums.NEErrorCode.LoginSerialNoError, "Must Dependency NEPlatformLoginUpStream Class.");
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
