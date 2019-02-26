using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x80_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x80_Device jTNE_0X80_Device = new JTNE_0x80_Device();
            jTNE_0X80_Device.QueryTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X80_Device.ParamNum = 2;
            jTNE_0X80_Device.ParamList = new byte[] {0x01,0x02 };
            var hex = JTNESerializer_Device.Serialize(jTNE_0X80_Device).ToHexString();
            Assert.Equal("130116173738020102", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "130116173738020102".ToHexBytes();
            JTNE_0x80_Device jTNE_0X80_Device
                = JTNESerializer_Device.Deserialize<JTNE_0x80_Device>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X80_Device.QueryTime);
            Assert.Equal(2, jTNE_0X80_Device.ParamNum);
            Assert.Equal(new byte[] { 0x01, 0x02 }, jTNE_0X80_Device.ParamList);
        }
    }
}
