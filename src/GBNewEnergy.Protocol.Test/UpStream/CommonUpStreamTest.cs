using GBNewEnergy.Protocol.NEProperties;
using GBNewEnergy.Protocol.UpStream;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using GBNewEnergy.Protocol.Extensions;

namespace GBNewEnergy.Protocol.Test.UpStream
{
    public class CommonUpStreamTest: NEPackageBase
    {
        #region 控制应答
        [Fact]
        public void NEControlTest1_1()
        {
            // "23 23 82 01 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 06 12 06 0C 0B 21 08 96"
            CommonUpStream nEControlDownStream = new CommonUpStream(new NEEmptyProperty(), NEGlobalConfigs);
            INEProperties nEPackageProperty = new NEPackageProperty
            {
                Bodies = nEControlDownStream,
                MsgId = Enums.NEMsgId.control,
                AskId = Enums.NEAskId.success,
                VIN = "LGHC4V1D3HE202652"
            };
            NEPackage nEPackage = new NEPackage(nEPackageProperty, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }

        [Fact]
        public void NEControlTest1_2()
        {
            // "23 23 82 01 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 06 12 06 0C 0B 21 08 96"
            byte[] packageBytes = "23 23 82 01 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 06 12 06 0C 0B 21 08 96".ToHexBytes();
            NEPackage nEPackage = new NEPackage(packageBytes, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }
        #endregion

        #region 设置应答
        [Fact]
        public void NESettingsTest1_1()
        {
            // "23 23 81 01 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 06 12 06 0C 0B 23 15 8A"
            CommonUpStream nESettingsDownStream = new CommonUpStream(new NEEmptyProperty(), NEGlobalConfigs);
            INEProperties nEPackageProperty = new NEPackageProperty
            {
                Bodies = nESettingsDownStream,
                MsgId = Enums.NEMsgId.settings,
                AskId = Enums.NEAskId.success,
                VIN = "LGHC4V1D3HE202652"
            };
            NEPackage nEPackage = new NEPackage(nEPackageProperty, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }

        [Fact]
        public void NESettingsTest1_2()
        {
            byte[] packageBytes = "23 23 81 01 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 06 12 06 0C 0B 23 15 8A".ToHexBytes();
            NEPackage nEPackage = new NEPackage(packageBytes, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }
        #endregion

        #region 心跳

        [Fact]
        public void NEHeartbeatTest1_1()
        {
            // "23 23 81 01 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 06 12 06 0C 0B 23 15 8A"
            CommonUpStream nESettingsDownStream = new CommonUpStream(new NEEmptyProperty(), NEGlobalConfigs);
            INEProperties nEPackageProperty = new NEPackageProperty
            {
                Bodies = nESettingsDownStream,
                MsgId = Enums.NEMsgId.heartbeat,
                AskId = Enums.NEAskId.cmd,
                VIN = "LGHC4V1D3HE202652"
            };
            NEPackage nEPackage = new NEPackage(nEPackageProperty, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }

        [Fact]
        public void NEHeartbeatTest1_2()
        {
            // "23 23 81 01 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 06 12 06 0C 0B 23 15 8A"
            CommonUpStream nESettingsDownStream = new CommonUpStream(new NEEmptyProperty(), NEGlobalConfigs);
            INEProperties nEPackageProperty = new NEPackageProperty
            {
                Bodies = nESettingsDownStream,
                MsgId = Enums.NEMsgId.heartbeat,
                AskId = Enums.NEAskId.success,
                VIN = "LGHC4V1D3HE202652"
            };
            NEPackage nEPackage = new NEPackage(nEPackageProperty, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }

        #endregion

        #region 终端校时
        [Fact]
        public void NECheckTimeTest1_1()
        {
            // "23 23 81 01 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 06 12 06 0C 0B 23 15 8A"
            CommonUpStream nESettingsDownStream = new CommonUpStream(new NEEmptyProperty(), NEGlobalConfigs);
            INEProperties nEPackageProperty = new NEPackageProperty
            {
                Bodies = nESettingsDownStream,
                MsgId = Enums.NEMsgId.checktime,
                AskId = Enums.NEAskId.cmd,
                VIN = "LGHC4V1D3HE202652"
            };
            NEPackage nEPackage = new NEPackage(nEPackageProperty, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        }

        [Fact]
        public void NECheckTimeTest1_2()
        {
            // "23 23 81 01 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 06 12 06 0C 0B 23 15 8A"
            CommonUpStream nESettingsDownStream = new CommonUpStream(new NEEmptyProperty(), NEGlobalConfigs);
            INEProperties nEPackageProperty = new NEPackageProperty
            {
                Bodies = nESettingsDownStream,
                MsgId = Enums.NEMsgId.checktime,
                AskId = Enums.NEAskId.success,
                VIN = "LGHC4V1D3HE202652"
            };
            NEPackage nEPackage = new NEPackage(nEPackageProperty, NEGlobalConfigs);
            string headerHex = nEPackage.Header.ToHexString();
            string bodiesHex = nEPackage.Bodies.Buffer.ToHexString();
            string packageHex = nEPackage.Buffer.ToHexString();
        } 
        #endregion
    }
}
