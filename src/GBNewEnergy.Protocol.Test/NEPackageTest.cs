using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using GBNewEnergy.Protocol.Extensions;
using GBNewEnergy.Protocol.UpStream;
using GBNewEnergy.Protocol.Enums;
using GBNewEnergy.Protocol.Exceptions;
using GBNewEnergy.Protocol.NEProperties;

namespace GBNewEnergy.Protocol.Test
{
    public class NEPackageTest
    {
        private readonly NEGlobalConfigs NEGlobalConfigs = new NEGlobalConfigs()
        {
             NEEncryptKey="smallchi" 
        };
        #region 车辆登入
        [Fact]
        public void NELoginUpStreamConstructor4_1()
        {
            // "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F"
            // "12 06 08 11 09 14 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31"
            // "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F 12 06 08 11 09 14 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31 DA"
            INEProperties nELoginProperty = new NELoginProperty
            {
                 VIN= "LGHC4V1D3HE202652",
                 BatteryCount=1,
                 BatteryLength=1,
                 BatteryNos=new List<string>() { "1" },
                 SIM= "64743066405"
            };
            NELoginUpStream nELoginUpStream = new NELoginUpStream(nELoginProperty, NEGlobalConfigs);
            INEProperties nEPackageProperty = new NEPackageProperty
            {
                 Bodies= nELoginUpStream,
                 MsgId = Enums.NEMsgId.login,
                 AskId= Enums.NEAskId.cmd,
                 VIN= "LGHC4V1D3HE202652"
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
            NEPackage nEPackage = new NEPackage(header, body,NEGlobalConfigs);
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

        #region 车辆登出(依赖车辆登录的流水号所有必须先进行登录产生流水号)

        [Fact]
        public void NELogoutUpStream1_1()
        {
            try
            {
                INEProperties nELogoutProperty = new NELogoutProperty()
                {
                    VIN = "LGHC4V1D3HE202652"
                };
                NELogoutUpStream nELogoutUpStream1 = new NELogoutUpStream(nELogoutProperty, NEGlobalConfigs);
                INEProperties nEPackageProperty1 = new NEPackageProperty
                {
                    Bodies = nELogoutUpStream1,
                    MsgId = Enums.NEMsgId.login,
                    AskId = Enums.NEAskId.cmd,
                    VIN = "LGHC4V1D3HE202652"
                };
                NEPackage nEPackage = new NEPackage(nEPackageProperty1, NEGlobalConfigs);
                string headerHex = nEPackage.Header.ToHexString();
                string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
                string packageHex = nEPackage.Buffer.ToHexString();
            }
            catch (NEException ex)
            {
                Assert.Equal(NEErrorCode.LoginSerialNoError, ex.ErrorCode);
            }
        }

        [Fact]
        public void NELogoutUpStream2_1()
        {
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
            NEPackage nEPackageLogin = new NEPackage(nEPackageProperty, NEGlobalConfigs);
            INEProperties nELogoutProperty = new NELogoutProperty()
            {
                VIN = "LGHC4V1D3HE202652"
            };
            NELogoutUpStream nELogoutUpStream1 = new NELogoutUpStream(nELogoutProperty, NEGlobalConfigs);
            INEProperties nEPackageProperty1 = new NEPackageProperty
            {
                Bodies = nELogoutUpStream1,
                MsgId = Enums.NEMsgId.loginout,
                AskId = Enums.NEAskId.cmd,
                VIN = "LGHC4V1D3HE202652"
            };
            NEPackage nEPackage = new NEPackage(nEPackageProperty1, NEGlobalConfigs);
            // "23 23 05 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 08"
            // "12 06 08 12 06 3A 00 01"
            // "23 23 05 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 08 12 06 08 12 06 3A 00 01 E9"
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }

        [Fact]
        public void NELogoutUpStream2_2()
        {
            byte[] packageBytes = "23 23 05 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 08 12 06 08 12 06 3A 00 01 E9".ToHexBytes();
            NEPackage nEPackage = new NEPackage(packageBytes, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
            Assert.Equal("23 23 05 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 08", headerHex);
            Assert.Equal("12 06 08 12 06 3A 00 01 E9", bodiesHex);
        }

        #endregion

    }
}
