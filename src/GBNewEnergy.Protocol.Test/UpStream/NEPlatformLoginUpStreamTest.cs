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
    public class NEPlatformLoginUpStreamTest:NEPackageBase
    {
        #region 平台登入

        [Fact]
        public void NEPlatformLogin1_1()
        {
            // "23 23 05 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 29 12 06 0C 09 2F 12 00 01 00 00 00 00 73 6D 61 6C 6C 63 68 69 31 32 33 34 35 36 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 CD"
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
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }

        [Fact]
        public void NEPlatformLogin1_2()
        {
            byte[] packageBytes = "23 23 05 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 29 12 06 0C 09 2F 12 00 01 00 00 00 00 73 6D 61 6C 6C 63 68 69 31 32 33 34 35 36 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 CD".ToHexBytes();
            NEPackage nEPackage = new NEPackage(packageBytes, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }

        #endregion
    }
}
