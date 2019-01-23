using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x01Test
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x01 jTNE_0X01 = new JTNE_0x01();
            jTNE_0X01.PDATime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X01.LoginNum = 1;
            jTNE_0X01.BatteryLength = 0x04;
            jTNE_0X01.SIM = "12345678998765432100";
            jTNE_0X01.BatteryNos = new List<string>()
            {
               "1234",
               "4567",
               "9870"
            };
            var hex = JTNESerializer.Serialize(jTNE_0X01).ToHexString();
            Assert.Equal("130116173738000131323334353637383939383736353433323130300304313233343435363739383730", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "130116173738000131323334353637383939383736353433323130300304313233343435363739383730".ToHexBytes();
            JTNE_0x01 jTNE_0X01 = JTNESerializer.Deserialize<JTNE_0x01>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X01.PDATime);
            Assert.Equal(1, jTNE_0X01.LoginNum);
            Assert.Equal(0x04, jTNE_0X01.BatteryLength);
            Assert.Equal("12345678998765432100", jTNE_0X01.SIM);
            Assert.Equal(3, jTNE_0X01.BatteryCount);
            Assert.Equal("1234", jTNE_0X01.BatteryNos[0]);
            Assert.Equal("4567", jTNE_0X01.BatteryNos[1]);
            Assert.Equal("9870", jTNE_0X01.BatteryNos[2]);
        }
    }
}
