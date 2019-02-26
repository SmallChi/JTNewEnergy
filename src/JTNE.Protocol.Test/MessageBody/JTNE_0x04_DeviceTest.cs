using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x04_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x04_Device jTNE_0X04_Device = new JTNE_0x04_Device();
            jTNE_0X04_Device.LogoutTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X04_Device.LogoutNum = 4444;
            var hex = JTNESerializer_Device.Serialize(jTNE_0X04_Device).ToHexString();
            Assert.Equal("130116173738115C", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "130116173738115C".ToHexBytes();
            JTNE_0x04_Device jTNE_0X04_Device = JTNESerializer_Device.Deserialize<JTNE_0x04_Device>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X04_Device.LogoutTime);
            Assert.Equal(4444, jTNE_0X04_Device.LogoutNum);
        }
    }
}
