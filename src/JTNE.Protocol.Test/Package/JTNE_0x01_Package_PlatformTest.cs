using JTNE.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Enums;
using JTNE.Protocol.MessageBody;
using JTNE.Protocol.Internal;

namespace JTNE.Protocol.Test.Package
{
    public class JTNE_0x01_Package_PlatformTest
    {
        [Fact]
        public void Test1()
        {
            JTNEPackage_Platform jTNEPackage_Platform = new JTNEPackage_Platform();
            jTNEPackage_Platform.AskId = JTNEAskId.CMD.ToByteValue();
            jTNEPackage_Platform.MsgId = JTNEMsgId_Platform.login.ToByteValue();
            jTNEPackage_Platform.VIN = "123456789";
            JTNE_0x01_Platform jTNE_0X01_Platform = new JTNE_0x01_Platform();
            jTNE_0X01_Platform.PDATime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X01_Platform.LoginNum = 1;
            jTNE_0X01_Platform.BatteryLength = 0x04;
            jTNE_0X01_Platform.SIM = "12345678998765432100";
            jTNE_0X01_Platform.BatteryNos = new List<string>()
            {
               "1234",
               "4567",
               "9870"
            };
            jTNEPackage_Platform.Bodies = jTNE_0X01_Platform;
            var hex = JTNESerializer_Platform.Serialize(jTNEPackage_Platform).ToHexString();
            Assert.Equal("232301FE313233343536373839000000000000000001002A130116173738000131323334353637383939383736353433323130300304313233343435363739383730FD", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "232301FE313233343536373839000000000000000001002A130116173738000131323334353637383939383736353433323130300304313233343435363739383730FD".ToHexBytes();
            JTNEPackage_Platform jTNEPackage_Platform = JTNESerializer_Platform.Deserialize<JTNEPackage_Platform>(data);
            Assert.Equal(JTNEAskId.CMD.ToByteValue(), jTNEPackage_Platform.AskId);
            Assert.Equal(JTNEMsgId_Platform.login.ToByteValue(), jTNEPackage_Platform.MsgId);
            Assert.Equal("123456789", jTNEPackage_Platform.VIN);

            JTNE_0x01_Platform jTNE_0X01_Platform = jTNEPackage_Platform.Bodies as JTNE_0x01_Platform;
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X01_Platform.PDATime);
            Assert.Equal(1, jTNE_0X01_Platform.LoginNum);
            Assert.Equal(0x04, jTNE_0X01_Platform.BatteryLength);
            Assert.Equal("12345678998765432100", jTNE_0X01_Platform.SIM);
            Assert.Equal(3, jTNE_0X01_Platform.BatteryCount);
            Assert.Equal("1234", jTNE_0X01_Platform.BatteryNos[0]);
            Assert.Equal("4567", jTNE_0X01_Platform.BatteryNos[1]);
            Assert.Equal("9870", jTNE_0X01_Platform.BatteryNos[2]);
        }

        [Fact]
        public void Test3()
        {
            JTNEGlobalConfigs.Instance.SetDataBodiesEncrypt((msgId) =>
            {
                switch (msgId)
                {
                    case 0x03:
                        return new Default_AES128EncryptImpl();
                    default:
                        return default;
                }
            });
            JTNEPackage_Platform jTNEPackage_Platform = new JTNEPackage_Platform();
            jTNEPackage_Platform.AskId = JTNEAskId.CMD.ToByteValue();
            jTNEPackage_Platform.MsgId = JTNEMsgId_Platform.login.ToByteValue();
            jTNEPackage_Platform.VIN = "123456789";
            jTNEPackage_Platform.EncryptMethod = JTNEEncryptMethod.AES128.ToByteValue();
            JTNE_0x01_Platform jTNE_0X01_Platform = new JTNE_0x01_Platform();
            jTNE_0X01_Platform.PDATime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X01_Platform.LoginNum = 1;
            jTNE_0X01_Platform.BatteryLength = 0x04;
            jTNE_0X01_Platform.SIM = "12345678998765432100";
            jTNE_0X01_Platform.BatteryNos = new List<string>()
            {
               "1234",
               "4567",
               "9870"
            };
            jTNEPackage_Platform.Bodies = jTNE_0X01_Platform;
            var hex = JTNESerializer_Device.Serialize(jTNEPackage_Platform).ToHexString();
            Assert.Equal("232301FE31323334353637383900000000000000000300307C9AAF67FB9408A75FAFC1C87F1E2AECD79DDAB8219016A5DD0911283922805EF450045EA3611C0D5CFBFD8F2581CEED30", hex);
        }

        [Fact]
        public void Test4()
        {
            JTNEGlobalConfigs.Instance.SetDataBodiesEncrypt((msgId) =>
            {
                switch (msgId)
                {
                    case 0x03:
                        return new Default_AES128EncryptImpl();
                    default:
                        return default;
                }
            });
            var data = "232301FE31323334353637383900000000000000000300307C9AAF67FB9408A75FAFC1C87F1E2AECD79DDAB8219016A5DD0911283922805EF450045EA3611C0D5CFBFD8F2581CEED30".ToHexBytes();
            JTNEPackage_Platform jTNEPackage_Platform = JTNESerializer_Platform.Deserialize(data);
            Assert.Equal(JTNEAskId.CMD.ToByteValue(), jTNEPackage_Platform.AskId);
            Assert.Equal(JTNEMsgId_Device.login.ToByteValue(), jTNEPackage_Platform.MsgId);
            Assert.Equal("123456789", jTNEPackage_Platform.VIN);
            Assert.Equal(JTNEEncryptMethod.AES128.ToByteValue(), jTNEPackage_Platform.EncryptMethod);

            JTNE_0x01_Platform jTNE_0X01_Platform = jTNEPackage_Platform.Bodies as JTNE_0x01_Platform;
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X01_Platform.PDATime);
            Assert.Equal(1, jTNE_0X01_Platform.LoginNum);
            Assert.Equal(0x04, jTNE_0X01_Platform.BatteryLength);
            Assert.Equal("12345678998765432100", jTNE_0X01_Platform.SIM);
            Assert.Equal(3, jTNE_0X01_Platform.BatteryCount);
            Assert.Equal("1234", jTNE_0X01_Platform.BatteryNos[0]);
            Assert.Equal("4567", jTNE_0X01_Platform.BatteryNos[1]);
            Assert.Equal("9870", jTNE_0X01_Platform.BatteryNos[2]);
        }
    }
}
