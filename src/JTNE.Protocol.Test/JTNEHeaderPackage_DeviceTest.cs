using JTNE.Protocol.Enums;
using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JTNE.Protocol.Test
{
    public class JTNEHeaderPackage_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNEHeaderPackage_Device jTNEHeaderPackage = new JTNEHeaderPackage_Device();
            jTNEHeaderPackage.VIN = "123456789";
            jTNEHeaderPackage.AskId = JTNEAskId.CMD.ToByteValue();
            jTNEHeaderPackage.MsgId = JTNEMsgId_Device.login.ToByteValue();
            JTNE_0x01_Device jTNE_0X01_Device = new JTNE_0x01_Device();
            jTNE_0X01_Device.PDATime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X01_Device.LoginNum = 1;
            jTNE_0X01_Device.BatteryLength = 0x04;
            jTNE_0X01_Device.SIM = "12345678998765432100";
            jTNE_0X01_Device.BatteryNos = new List<string>()
            {
               "1234",
               "4567",
               "9870"
            };
            jTNEHeaderPackage.Bodies = JTNESerializer_Device.Serialize(jTNE_0X01_Device);
            var hex = JTNESerializer_Device.Serialize(jTNEHeaderPackage).ToHexString();
            Assert.Equal("232301FE313233343536373839000000000000000001002A130116173738000131323334353637383939383736353433323130300304313233343435363739383730FD", hex);
        }

        [Fact]
        public void Test2()
        {
            var data= "232301FE313233343536373839000000000000000001002A130116173738000131323334353637383939383736353433323130300304313233343435363739383730FD".ToHexBytes();
            JTNEHeaderPackage_Device jTNEHeaderPackage = JTNESerializer_Device.Deserialize<JTNEHeaderPackage_Device>(data);
            Assert.Equal(JTNEAskId.CMD.ToByteValue(), jTNEHeaderPackage.AskId);
            Assert.Equal(JTNEMsgId_Device.login.ToByteValue(), jTNEHeaderPackage.MsgId);
            Assert.Equal("123456789", jTNEHeaderPackage.VIN);
            JTNE_0x01_Device jTNE_0X01_Device = JTNESerializer_Device.Deserialize<JTNE_0x01_Device>(jTNEHeaderPackage.Bodies);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X01_Device.PDATime);
            Assert.Equal(1, jTNE_0X01_Device.LoginNum);
            Assert.Equal(0x04, jTNE_0X01_Device.BatteryLength);
            Assert.Equal("12345678998765432100", jTNE_0X01_Device.SIM);
            Assert.Equal(3, jTNE_0X01_Device.BatteryCount);
            Assert.Equal("1234", jTNE_0X01_Device.BatteryNos[0]);
            Assert.Equal("4567", jTNE_0X01_Device.BatteryNos[1]);
            Assert.Equal("9870", jTNE_0X01_Device.BatteryNos[2]);
        }     
    }
}
