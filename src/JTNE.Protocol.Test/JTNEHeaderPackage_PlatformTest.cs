using JTNE.Protocol.Enums;
using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JTNE.Protocol.Test
{
    public class JTNEHeaderPackage_PlatformTest
    {
        [Fact]
        public void Test1()
        {
            JTNEHeaderPackage_Platform jTNEHeaderPackage_Platform = new JTNEHeaderPackage_Platform();
            jTNEHeaderPackage_Platform.VIN = "123456789";
            jTNEHeaderPackage_Platform.AskId = JTNEAskId.CMD.ToByteValue();
            jTNEHeaderPackage_Platform.MsgId = JTNEMsgId_Platform.login.ToByteValue();
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
            jTNEHeaderPackage_Platform.Bodies = JTNESerializer_Platform.Serialize(jTNE_0X01_Platform);
            var hex = JTNESerializer_Platform.Serialize(jTNEHeaderPackage_Platform).ToHexString();
            Assert.Equal("232301FE313233343536373839000000000000000001002A130116173738000131323334353637383939383736353433323130300304313233343435363739383730FD", hex);
        }
        [Fact]
        public void Test2()
        {
            var data = "232301FE313233343536373839000000000000000001002A130116173738000131323334353637383939383736353433323130300304313233343435363739383730FD".ToHexBytes();
            JTNEHeaderPackage_Platform jTNEHeaderPackage_Platform = JTNESerializer_Platform.Deserialize<JTNEHeaderPackage_Platform>(data);
            Assert.Equal(JTNEAskId.CMD.ToByteValue(), jTNEHeaderPackage_Platform.AskId);
            Assert.Equal(JTNEMsgId_Platform.login.ToByteValue(), jTNEHeaderPackage_Platform.MsgId);
            Assert.Equal("123456789", jTNEHeaderPackage_Platform.VIN);
            JTNE_0x01_Platform jTNE_0X01_Platform = JTNESerializer_Platform.Deserialize<JTNE_0x01_Platform>(jTNEHeaderPackage_Platform.Bodies);
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
