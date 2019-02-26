using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x01_DeviceTest
    {
        [Fact]
        public void Test1()
        {
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
            var hex = JTNESerializer_Device.Serialize(jTNE_0X01_Device).ToHexString();
            Assert.Equal("130116173738000131323334353637383939383736353433323130300304313233343435363739383730", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "130116173738000131323334353637383939383736353433323130300304313233343435363739383730".ToHexBytes();
            JTNE_0x01_Device jTNE_0X01_Device = JTNESerializer_Device.Deserialize<JTNE_0x01_Device>(data);
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
