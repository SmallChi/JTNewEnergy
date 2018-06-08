using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using GBNewEnergy.Protocol.Extensions;
using GBNewEnergy.Protocol.UpStream;
using GBNewEnergy.Protocol.Enums;
using GBNewEnergy.Protocol.Exceptions;

namespace GBNewEnergy.Protocol.Test
{
    public class NEPackageTest
    {
        #region 车辆登入
        [Fact]
        public void NELoginUpStreamConstructor1_1()
        {
            // "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F"
            // "12 06 07 11 04 1B 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31"
            // "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F 12 06 07 11 04 1B 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31 D7"
            NELoginUpStream nELoginUpStream = new NELoginUpStream("LGHC4V1D3HE202652", "64743066405", 1, 1, new string[] { "1" });
            NEPackage nEPackage = new NEPackage("LGHC4V1D3HE202652", Enums.MsgId.login, Enums.AskId.cmd, nELoginUpStream, EncryptMethod.None);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }

        [Fact]
        public void NELoginUpStreamConstructor1_2()
        {
            byte[] header = "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F".ToHexBytes();
            byte[] body = "12 06 07 11 04 1B 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31 D7".ToHexBytes();
            NEPackage nEPackage = new NEPackage(header, body);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
        }

        [Fact]
        public void NELoginUpStreamConstructor2_1()
        {
            // "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F"
            // "12 06 07 12 23 3B 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31"
            // "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F 12 06 07 12 23 3B 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31 D3"
            NELoginUpStream nELoginUpStream = new NELoginUpStream("LGHC4V1D3HE202652", "64743066405", 1, 1, new string[] { "1" });
            NEPackage nEPackage = new NEPackage("LGHC4V1D3HE202652", Enums.MsgId.login, Enums.AskId.cmd, nELoginUpStream, EncryptMethod.None);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }

        [Fact]
        public void NELoginUpStreamConstructor2_2()
        {
            byte[] header = "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F".ToHexBytes();
            byte[] body = "12 06 07 12 23 3B 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31 D3".ToHexBytes();
            NEPackage nEPackage = new NEPackage(header, body);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
        }

        [Fact]
        public void NELoginUpStreamConstructor3_1()
        {
            // "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F"
            // "12 06 08 0A 26 2E 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31"
            // "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F 12 06 08 0A 26 2E 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31 D4"
            NELoginUpStream nELoginUpStream = new NELoginUpStream("LGHC4V1D3HE202652", "64743066405", 1, 1, new string[] { "1" });
            NEPackage nEPackage = new NEPackage("LGHC4V1D3HE202652", Enums.MsgId.login, Enums.AskId.cmd, nELoginUpStream, EncryptMethod.None);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }

        [Fact]
        public void NELoginUpStreamConstructor3_2()
        {
            byte[] header = "23 23 01 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 1F".ToHexBytes();
            byte[] body = "12 06 08 0A 26 2E 00 01 36 34 37 34 33 30 36 36 34 30 35 00 00 00 00 00 00 00 00 00 01 01 31 D4".ToHexBytes();
            NEPackage nEPackage = new NEPackage(header, body);
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
                NELoginUpStream nELoginUpStream = new NELoginUpStream("LGHC4V1D3HE202652", "64743066405", 1, 1, new string[] { "1" });
                NELogoutUpStream eLogoutUpStream = new NELogoutUpStream("LGHC4V1D3HE202652");
                NEPackage nEPackage = new NEPackage("LGHC4V1D3HE202652", Enums.MsgId.loginout, Enums.AskId.cmd, eLogoutUpStream, EncryptMethod.None);
            }
            catch (NEException ex)
            {
                Assert.Equal(ErrorCode.LoginSerialNoError, ex.ErrorCode);
            }
        }

        [Fact]
        public void NELogoutUpStream2_1()
        {
             // 先进行车辆登入 
             NELoginUpStream nELoginUpStream = new NELoginUpStream("LGHC4V1D3HE202652", "64743066405", 1, 1, new string[] { "1" });
            // "23 23 05 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 08"
            // "12 06 08 0B 2B 0A 00 01"
            // "23 23 05 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 08 12 06 08 0B 2B 0A 00 01 ED"
            // 车辆登出
             NELogoutUpStream eLogoutUpStream = new NELogoutUpStream("LGHC4V1D3HE202652");
             NEPackage nEPackage = new NEPackage("LGHC4V1D3HE202652", Enums.MsgId.loginout, Enums.AskId.cmd, eLogoutUpStream, EncryptMethod.None);
             string headerHex = nEPackage.Header.ToHexString();
             string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
             string packageHex = nEPackage.Buffer.ToHexString();
        }

        [Fact]
        public void NELogoutUpStream2_2()
        {
            byte[] header = "23 23 05 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 08".ToHexBytes();
            byte[] body = "12 06 08 0B 2B 0A 00 01 ED".ToHexBytes();
            NEPackage nEPackage = new NEPackage(header, body);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
            Assert.Equal("23 23 05 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 08", headerHex);
            Assert.Equal("12 06 08 0B 2B 0A 00 01 ED", bodiesHex);
        }

        #endregion

    }
}
