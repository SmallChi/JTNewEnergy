using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x80Test
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x80 jTNE_0X80 = new JTNE_0x80();
            jTNE_0X80.QueryTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X80.ParamNum = 2;
            jTNE_0X80.ParamList = new byte[] {0x01,0x02 };
            var hex = JTNESerializer.Serialize(jTNE_0X80).ToHexString();
            Assert.Equal("130116173738020102", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "130116173738020102".ToHexBytes();
            JTNE_0x80 jTNE_0X80 = JTNESerializer.Deserialize<JTNE_0x80>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X80.QueryTime);
            Assert.Equal(2, jTNE_0X80.ParamNum);
            Assert.Equal(new byte[] { 0x01, 0x02 }, jTNE_0X80.ParamList);
        }
    }
}
