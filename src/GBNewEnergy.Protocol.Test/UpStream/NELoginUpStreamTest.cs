using GBNewEnergy.Protocol.NEProperties;
using GBNewEnergy.Protocol.UpStream;
using GBNewEnergy.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GBNewEnergy.Protocol.Test.UpStream
{
   public class NELoginUpStreamTest:NEPackageTest
    {
        #region 车辆登入
        [Fact]
        public void NELoginUpStreamConstructor4_1()
        {
            // "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F"
            // "12 06 08 11 09 14 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31"
            // "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F 12 06 08 11 09 14 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31 DA"
            INEProperties nELoginProperty = new NELoginProperty
            {
                VIN = "LGHC4V1D3HE202652",
                BatteryCount = 1,
                BatteryLength = 1,
                BatteryNos = new List<string>() { "1" },
                SIM = "64743066405"
            };
            NELoginUpStream nELoginUpStream = new NELoginUpStream(nELoginProperty, NEGlobalConfigs);
            INEProperties nEPackageProperty = new NEPackageProperty
            {
                Bodies = nELoginUpStream,
                MsgId = Enums.NEMsgId.login,
                AskId = Enums.NEAskId.cmd,
                VIN = "LGHC4V1D3HE202652"
            };
            NEPackage nEPackage = new NEPackage(nEPackageProperty, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }
        [Fact]
        public void NELoginUpStreamConstructor4_2()
        {
            // "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F"
            // "12 06 07 11 04 1B 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31"
            // "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F 12 06 07 11 04 1B 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31 D7"
            byte[] header = "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F".ToHexBytes();
            byte[] body = "12 06 07 11 04 1B 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31 D7".ToHexBytes();
            NEPackage nEPackage = new NEPackage(header, body, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }
        [Fact]
        public void NELoginUpStreamConstructor4_3()
        {

            // "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F 12 06 07 11 04 1B 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31 D7"
            byte[] packageBytes = "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F 12 06 07 11 04 1B 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31 D7".ToHexBytes();
            NEPackage nEPackage = new NEPackage(packageBytes, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }
        #endregion
    }
}
