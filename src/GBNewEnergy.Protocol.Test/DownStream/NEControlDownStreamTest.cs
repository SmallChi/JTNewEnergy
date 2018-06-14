using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using GBNewEnergy.Protocol.Extensions;
using GBNewEnergy.Protocol.NEProperties;
using GBNewEnergy.Protocol.DownStream;
using GBNewEnergy.Protocol.Enums;

namespace GBNewEnergy.Protocol.Test.DownStream
{
    public class NEControlDownStreamTest : NEPackageBase
    {
        #region NEControlCmd.unused
        [Fact]
        public void NEControlDownStreamConstructor4_1()
        {
            NEControlProperty nEControlProperty = new NEControlProperty
            {
                VIN = "LGHC4V1D3HE202652",
                 CmdID=NEControlCmd.unused,
                UpgradeParameter=new NEControlUpgradeParameter {
                    DialPassword = "123",
                    DialPointName = "xyz",
                    DialUserName = "11"
                }
            };
            NEControlDownStream nEControlDownStream = new NEControlDownStream(nEControlProperty, NEGlobalConfigs);
            INEProperties nEPackageProperty = new NEPackageProperty
            {
                Bodies = nEControlDownStream,
                MsgId = Enums.NEMsgId.control,
                AskId = Enums.NEAskId.cmd,
                VIN = "LGHC4V1D3HE202652"
            };
            NEPackage nEPackage = new NEPackage(nEPackageProperty, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }

        [Fact]
        public void NEControlDownStreamConstructor4_2()
        {
            byte[] packageBytes = "23 23 82 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 07 12 06 0E 0A 0E 1B 00 57".ToHexBytes();
            NEPackage nEPackage = new NEPackage(packageBytes, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }
        #endregion

        #region NEControlCmd.remoteupdate
        [Fact]
        public void NEControlDownStreamConstructor4_3()
        {
            NEControlProperty nEControlProperty = new NEControlProperty
            {
                VIN = "LGHC4V1D3HE202652",
                CmdID = NEControlCmd.remoteupdate,
                UpgradeParameter=new NEControlUpgradeParameter {
                    DialPassword = "123",
                    DialPointName = "xyz",
                    DialUserName = "11"
                }
            };
            NEControlDownStream nEControlDownStream = new NEControlDownStream(nEControlProperty, NEGlobalConfigs);
            INEProperties nEPackageProperty = new NEPackageProperty
            {
                Bodies = nEControlDownStream,
                MsgId = Enums.NEMsgId.control,
                AskId = Enums.NEAskId.cmd,
                VIN = "LGHC4V1D3HE202652"
            };
            NEPackage nEPackage = new NEPackage(nEPackageProperty, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }
        [Fact]
        public void NEControlDownStreamConstructor4_4()
        {
            byte[] packageBytes = "23 23 82 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 18 12 06 0E 0A 22 0B 01 3B 78 79 7A 3B 31 31 3B 31 32 33 3B 3B 3B 3B 3B 3B 05".ToHexBytes();
            NEPackage nEPackage = new NEPackage(packageBytes, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }
        #endregion

        #region NEControlCmd.warning
        [Fact]
        public void NEControlDownStreamConstructor4_5()
        {
            NEControlProperty nEControlProperty = new NEControlProperty
            {
                VIN = "LGHC4V1D3HE202652",
                CmdID = NEControlCmd.warning,
                 AlarmParameter= new NEControlAlarmParameter { nEAlarmLevel= NEAlarmLevel.一级报警 }
            };
            NEControlDownStream nEControlDownStream = new NEControlDownStream(nEControlProperty, NEGlobalConfigs);
            INEProperties nEPackageProperty = new NEPackageProperty
            {
                Bodies = nEControlDownStream,
                MsgId = Enums.NEMsgId.control,
                AskId = Enums.NEAskId.cmd,
                VIN = "LGHC4V1D3HE202652"
            };
            NEPackage nEPackage = new NEPackage(nEPackageProperty, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }
        [Fact]
        public void NEControlDownStreamConstructor4_6()
        {
            byte[] packageBytes = "23 23 82 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 08 12 06 0E 0B 2C 0B 06 01 6C".ToHexBytes();
            NEPackage nEPackage = new NEPackage(packageBytes, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }
        #endregion
    }
}
