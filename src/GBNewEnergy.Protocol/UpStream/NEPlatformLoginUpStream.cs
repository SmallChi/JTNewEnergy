using GBNewEnergy.Protocol.Enums;
using GBNewEnergy.Protocol.Extensions;
using GBNewEnergy.Protocol.NEProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.UpStream
{
    /// <summary>
    /// 平台登入
    /// </summary>
    public class NEPlatformLoginUpStream : NEBodies
    {
        public NEPlatformLoginUpStream(byte[] buffer, NEGlobalConfigs nEConfigs) : base(buffer, nEConfigs)
        {
        }

        public NEPlatformLoginUpStream(INEProperties nEProperties, NEGlobalConfigs nEConfigs) : base(nEProperties, nEConfigs)
        {
        }

        /// <summary>
        /// 平台用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 加密规则
        /// </summary>
        public NEEncryptMethod EncryptMethod { get; set; }

        /// <summary>
        /// 平台密码
        /// </summary>
        public string Password { get; set; }

        protected override void InitializeProperties(INEProperties nEProperties)
        {
            NEPlatformLoginProperty nEPlatformLoginProperty = (NEPlatformLoginProperty)nEProperties;
            if (PlatformLoginNumDict.ContainsKey(nEPlatformLoginProperty.UserName))
            {
                PlatformLoginInfo temp;
                if (PlatformLoginNumDict.TryGetValue(nEPlatformLoginProperty.UserName, out temp))
                {
                    // 不等于当天
                    if (temp.ExpirationTime != DateTime.Now.Date)
                    {
                        LoginNum = 1;
                        PlatformLoginNumDict.TryUpdate(nEPlatformLoginProperty.UserName, new PlatformLoginInfo { LoginNum = LoginNum, ExpirationTime = DateTime.Now.Date }, temp);
                    }
                    else
                    {// 自增1 更新字典
                        LoginNum = temp.LoginNum++;
                        PlatformLoginNumDict.TryUpdate(nEPlatformLoginProperty.UserName, new PlatformLoginInfo { LoginNum = LoginNum, ExpirationTime = DateTime.Now.Date }, temp);
                    }
                }
            }
            else
            {
                LoginNum = 1;
                PlatformLoginNumDict.TryAdd(nEPlatformLoginProperty.UserName, new PlatformLoginInfo { LoginNum = LoginNum, ExpirationTime = DateTime.Now.Date });
            }
            UserName = nEPlatformLoginProperty.UserName;
            EncryptMethod = nEPlatformLoginProperty.EncryptMethod;
            Password = nEPlatformLoginProperty.Password;
        }

        protected override void InitializePropertiesFromBuffer()
        {
            CurrentDateTime = Buffer.ReadDateTimeLittle(0, 6);
            LoginNum = Buffer.ReadUShortH2LLittle(6, 2);
            UserName = Buffer.ReadStringLittle(8, 12);
            Password = Buffer.ReadStringLittle(20, 20);
            EncryptMethod= (NEEncryptMethod)Buffer[40];
        }

        protected override void ToBuffer()
        {
            Buffer = new byte[6+2+12+20+1];
            Buffer.WriteLittle(CurrentDateTime, 0, 6);
            Buffer.WriteLittle(LoginNum, 6, 2);
            Buffer.WriteLittle(UserName, 12);
            Buffer.WriteLittle(Password, 20);
            Buffer.WriteLittle((byte)EncryptMethod, 40);
        }
    }
}
