using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x07Test
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x07 jTNE_0X02_0X07 = new JTNE_0x02_0x07();
            jTNE_0X02_0X07.AlarmBatteryFlag = 5533;
            jTNE_0X02_0X07.AlarmLevel = 0x11;
            jTNE_0X02_0X07.AlarmBatteryOthers = new List<uint>
            {
                1000,1001,1002
            };
            jTNE_0X02_0X07.AlarmEls = new List<uint>
            {
                2000,2001,2002
            };
            jTNE_0X02_0X07.AlarmEngines = new List<uint>
            {
                3000,3001,3002
            };
            jTNE_0X02_0X07.AlarmOthers = new List<uint>
            {
                4000,4001,4002
            };
            var hex = JTNESerializer.Serialize(jTNE_0X02_0X07).ToHexString();
            Assert.Equal("07110000159D03000003E8000003E9000003EA03000007D0000007D1000007D20300000BB800000BB900000BBA0300000FA000000FA100000FA2", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "07110000159D03000003E8000003E9000003EA03000007D0000007D1000007D20300000BB800000BB900000BBA0300000FA000000FA100000FA2".ToHexBytes();
            JTNE_0x02_0x07 jTNE_0X02_0X07 = JTNESerializer.Deserialize<JTNE_0x02_0x07>(data);
            Assert.Equal(JTNE_0x02_Body.JTNE_0x02_0x07, jTNE_0X02_0X07.TypeCode);
            Assert.Equal(0x11, jTNE_0X02_0X07.AlarmLevel);
            Assert.Equal(3, jTNE_0X02_0X07.AlarmBatteryOthers.Count);
            Assert.Equal(new List<uint>
            {
                1000,1001,1002
            }, jTNE_0X02_0X07.AlarmBatteryOthers);
            Assert.Equal(3, jTNE_0X02_0X07.AlarmEls.Count);
            Assert.Equal(new List<uint>
            {
                2000,2001,2002
            }, jTNE_0X02_0X07.AlarmEls);
            Assert.Equal(3, jTNE_0X02_0X07.AlarmEngines.Count);
            Assert.Equal(new List<uint>
            {
                3000,3001,3002
            }, jTNE_0X02_0X07.AlarmEngines);
            Assert.Equal(3, jTNE_0X02_0X07.AlarmOthers.Count);
            Assert.Equal(new List<uint>
            {
                4000,4001,4002
            }, jTNE_0X02_0X07.AlarmOthers);
        }
    }
}
