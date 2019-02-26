using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x07_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x07_Device jTNE_0X02_0X07_Device = new JTNE_0x02_0x07_Device();
            jTNE_0X02_0X07_Device.AlarmBatteryFlag = 5533;
            jTNE_0X02_0X07_Device.AlarmLevel = 0x11;
            jTNE_0X02_0X07_Device.AlarmBatteryOthers = new List<uint>
            {
                1000,1001,1002
            };
            jTNE_0X02_0X07_Device.AlarmEls = new List<uint>
            {
                2000,2001,2002
            };
            jTNE_0X02_0X07_Device.AlarmEngines = new List<uint>
            {
                3000,3001,3002
            };
            jTNE_0X02_0X07_Device.AlarmOthers = new List<uint>
            {
                4000,4001,4002
            };
            var hex = JTNESerializer_Device.Serialize(jTNE_0X02_0X07_Device).ToHexString();
            Assert.Equal("07110000159D03000003E8000003E9000003EA03000007D0000007D1000007D20300000BB800000BB900000BBA0300000FA000000FA100000FA2", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "07110000159D03000003E8000003E9000003EA03000007D0000007D1000007D20300000BB800000BB900000BBA0300000FA000000FA100000FA2".ToHexBytes();
            JTNE_0x02_0x07_Device jTNE_0X02_0X07_Device = JTNESerializer_Device.Deserialize<JTNE_0x02_0x07_Device>(data);
            Assert.Equal(JTNE_0x02_Body_Device.JTNE_0x02_0x07_Device, jTNE_0X02_0X07_Device.TypeCode);
            Assert.Equal(0x11, jTNE_0X02_0X07_Device.AlarmLevel);
            Assert.Equal(3, jTNE_0X02_0X07_Device.AlarmBatteryOthers.Count);
            Assert.Equal(new List<uint>
            {
                1000,1001,1002
            }, jTNE_0X02_0X07_Device.AlarmBatteryOthers);
            Assert.Equal(3, jTNE_0X02_0X07_Device.AlarmEls.Count);
            Assert.Equal(new List<uint>
            {
                2000,2001,2002
            }, jTNE_0X02_0X07_Device.AlarmEls);
            Assert.Equal(3, jTNE_0X02_0X07_Device.AlarmEngines.Count);
            Assert.Equal(new List<uint>
            {
                3000,3001,3002
            }, jTNE_0X02_0X07_Device.AlarmEngines);
            Assert.Equal(3, jTNE_0X02_0X07_Device.AlarmOthers.Count);
            Assert.Equal(new List<uint>
            {
                4000,4001,4002
            }, jTNE_0X02_0X07_Device.AlarmOthers);
        }
    }
}
