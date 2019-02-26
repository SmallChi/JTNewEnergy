using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x02_PlatformTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x02_Platform jTNE_0X02_0X02_Platform = new JTNE_0x02_0x02_Platform();
            jTNE_0X02_0X02_Platform.Electricals = new List<Metadata.Electrical>();
            Metadata.Electrical electrical1 = new Metadata.Electrical();
            electrical1.ElControlTemp = 0x01;
            electrical1.ElCurrent = 100;
            electrical1.ElNo = 0x01;
            electrical1.ElSpeed = 65;
            electrical1.ElStatus = 0x02;
            electrical1.ElTemp = 0x03;
            electrical1.ElTorque = 55;
            electrical1.ElVoltage = 236;
            Metadata.Electrical electrical2 = new Metadata.Electrical();
            electrical2.ElControlTemp = 0x02;
            electrical2.ElCurrent = 101;
            electrical2.ElNo = 0x02;
            electrical2.ElSpeed = 66;
            electrical2.ElStatus = 0x03;
            electrical2.ElTemp = 0x05;
            electrical2.ElTorque = 566;
            electrical2.ElVoltage = 2136;
            jTNE_0X02_0X02_Platform.Electricals.Add(electrical1);
            jTNE_0X02_0X02_Platform.Electricals.Add(electrical2);
            var hex = JTNESerializer_Platform.Serialize(jTNE_0X02_0X02_Platform).ToHexString();
            Assert.Equal("0202010201004100370300EC0064020302004202360508580065", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "0202010201004100370300EC0064020302004202360508580065".ToHexBytes();
            JTNE_0x02_0x02_Platform jTNE_0X02_0X02_Platform = JTNESerializer_Platform.Deserialize<JTNE_0x02_0x02_Platform>(data);
            Assert.Equal(JTNE_0x02_Body_Platform.JTNE_0x02_0x02_Platform, jTNE_0X02_0X02_Platform.TypeCode);
            Assert.Equal(2, jTNE_0X02_0X02_Platform.ElectricalCount);
            Metadata.Electrical electrical1 = jTNE_0X02_0X02_Platform.Electricals[0];
            Assert.Equal(0x01, electrical1.ElControlTemp);
            Assert.Equal(100, electrical1.ElCurrent);
            Assert.Equal(0x01, electrical1.ElNo);
            Assert.Equal(65, electrical1.ElSpeed);
            Assert.Equal(0x02, electrical1.ElStatus);
            Assert.Equal(0x03, electrical1.ElTemp);
            Assert.Equal(55, electrical1.ElTorque);
            Assert.Equal(236, electrical1.ElVoltage);
            Metadata.Electrical electrical2 = jTNE_0X02_0X02_Platform.Electricals[1];
            Assert.Equal(0x02, electrical2.ElControlTemp);
            Assert.Equal(101, electrical2.ElCurrent);
            Assert.Equal(0x02, electrical2.ElNo);
            Assert.Equal(66, electrical2.ElSpeed);
            Assert.Equal(0x03, electrical2.ElStatus);
            Assert.Equal(0x05, electrical2.ElTemp);
            Assert.Equal(566, electrical2.ElTorque);
            Assert.Equal(2136, electrical2.ElVoltage);
        }
    }
}
