using GBNewEnergy.Protocol.NEProperties;
using GBNewEnergy.Protocol.UpStream;
using GBNewEnergy.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using GBNewEnergy.Protocol.Enums;

namespace GBNewEnergy.Protocol.Test.UpStream
{
    public class NEPlatformLogoutUpStreamTest : NEPackageBase
    {

        #region 平台登出(依赖平台登出的流水号所有必须先进行登入产生流水号)

        [Fact]
        public void NEPlatformLogin2_1()
        {
            //"23 23 06 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 29 12 06 0C 09 3A 17 00 01 00 00 00 00 73 6D 61 6C 6C 63 68 69 31 32 33 34 35 36 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 DE"
            NEPlatformLoginProperty nEPlatformLoginProperty = new NEPlatformLoginProperty
            {
                EncryptMethod = NEEncryptMethod.None,
                Password = "123456",
                UserName = "smallchi",
            };
            NEPlatformLoginUpStream nEPlatformLoginUpStream = new NEPlatformLoginUpStream(nEPlatformLoginProperty, NEGlobalConfigs);
            INEProperties nEPackageProperty = new NEPackageProperty
            {
                Bodies = nEPlatformLoginUpStream,
                MsgId = Enums.NEMsgId.platformlogin,
                AskId = Enums.NEAskId.cmd,
                VIN = "LGHC4V1D3HE202652"
            };
            NEPackage nEPackage = new NEPackage(nEPackageProperty, NEGlobalConfigs);

            NEPlatformLogoutProperty nEPlatformLogoutProperty = new NEPlatformLogoutProperty
            {
                UserName = "smallchi",
            };
            NEPlatformLoginUpStream nEPlatformLogoutUpStream = new NEPlatformLoginUpStream(nEPlatformLoginProperty, NEGlobalConfigs);
            INEProperties logoutNEPackageProperty = new NEPackageProperty
            {
                Bodies = nEPlatformLogoutUpStream,
                MsgId = Enums.NEMsgId.platformlogout,
                AskId = Enums.NEAskId.cmd,
                VIN = "LGHC4V1D3HE202652"
            };
            NEPackage loginNEPackage = new NEPackage(logoutNEPackageProperty, NEGlobalConfigs);
            string headerHex = loginNEPackage.Header.ToHexString();
            string bodiesHex = loginNEPackage.Bodies.Buffer.ToHexString();
            string packageHex = loginNEPackage.Buffer.ToHexString();
        }

        [Fact]
        public void NEPlatformLogin2_2()
        {
            byte[] packageBytes = "23 23 06 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 29 12 06 0C 09 3A 17 00 01 00 00 00 00 73 6D 61 6C 6C 63 68 69 31 32 33 34 35 36 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 DE".ToHexBytes();
            NEPackage loginNEPackage = new NEPackage(packageBytes, NEGlobalConfigs);
            string headerHex = loginNEPackage.Header.ToHexString();
            string bodiesHex = loginNEPackage.Bodies.Buffer.ToHexString();
            string packageHex = loginNEPackage.Buffer.ToHexString();
        }

        #endregion
    }
}
