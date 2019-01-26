using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x02Test
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x02 jTNE_0X02_0X02 = new JTNE_0x02_0x02();
            jTNE_0X02_0X02.Electricals = new List<Metadata.Electrical>();
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
            jTNE_0X02_0X02.Electricals.Add(electrical1);
            jTNE_0X02_0X02.Electricals.Add(electrical2);
            var hex = JTNESerializer.Serialize(jTNE_0X02_0X02).ToHexString();
            Assert.Equal("0202010201004100370300EC0064020302004202360508580065", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "0202010201004100370300EC0064020302004202360508580065".ToHexBytes();
            JTNE_0x02_0x02 jTNE_0X02_0X02 = JTNESerializer.Deserialize<JTNE_0x02_0x02>(data);
            Assert.Equal(JTNE_0x02_Body.JTNE_0x02_0x02, jTNE_0X02_0X02.TypeCode);
            Assert.Equal(2, jTNE_0X02_0X02.ElectricalCount);
            Metadata.Electrical electrical1 = jTNE_0X02_0X02.Electricals[0];
            Assert.Equal(0x01, electrical1.ElControlTemp);
            Assert.Equal(100, electrical1.ElCurrent);
            Assert.Equal(0x01, electrical1.ElNo);
            Assert.Equal(65, electrical1.ElSpeed);
            Assert.Equal(0x02, electrical1.ElStatus);
            Assert.Equal(0x03, electrical1.ElTemp);
            Assert.Equal(55, electrical1.ElTorque);
            Assert.Equal(236, electrical1.ElVoltage);
            Metadata.Electrical electrical2 = jTNE_0X02_0X02.Electricals[1];
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
