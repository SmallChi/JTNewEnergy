using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x06Test
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x06 jTNE_0X02_0X06 = new JTNE_0x02_0x06();
            jTNE_0X02_0X06.MaxTempBatteryAssemblyNo = 0x12;
            jTNE_0X02_0X06.MaxTempProbeBatteryNo = 0x32;
            jTNE_0X02_0X06.MaxTempProbeBatteryValue = 0x42;
            jTNE_0X02_0X06.MaxVoltageBatteryAssemblyNo = 0x11;
            jTNE_0X02_0X06.MaxVoltageSingleBatteryNo = 0x15;
            jTNE_0X02_0X06.MaxVoltageSingleBatteryValue = 123;
            jTNE_0X02_0X06.MinTempBatteryAssemblyNo = 0x32;
            jTNE_0X02_0X06.MinTempProbeBatteryNo = 0x11;
            jTNE_0X02_0X06.MinTempProbeBatteryValue = 0x06;
            jTNE_0X02_0X06.MinVoltageBatteryAssemblyNo = 0x07;
            jTNE_0X02_0X06.MinVoltageSingleBatteryNo = 0x09;
            jTNE_0X02_0X06.MinVoltageSingleBatteryValue = 0x08;
            var hex = JTNESerializer.Serialize(jTNE_0X02_0X06).ToHexString();
            Assert.Equal("061115007B07090008321242113206", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "061115007B07090008321242113206".ToHexBytes();
            JTNE_0x02_0x06 jTNE_0X02_0X06 = JTNESerializer.Deserialize<JTNE_0x02_0x06>(data);
            Assert.Equal(0x12, jTNE_0X02_0X06.MaxTempBatteryAssemblyNo);
            Assert.Equal(0x32, jTNE_0X02_0X06.MaxTempProbeBatteryNo);
            Assert.Equal(0x42, jTNE_0X02_0X06.MaxTempProbeBatteryValue);
            Assert.Equal(0x11, jTNE_0X02_0X06.MaxVoltageBatteryAssemblyNo);
            Assert.Equal(0x15, jTNE_0X02_0X06.MaxVoltageSingleBatteryNo);
            Assert.Equal(123, jTNE_0X02_0X06.MaxVoltageSingleBatteryValue);
            Assert.Equal(0x11, jTNE_0X02_0X06.MinTempProbeBatteryNo);
            Assert.Equal(0x06, jTNE_0X02_0X06.MinTempProbeBatteryValue);
            Assert.Equal(0x07, jTNE_0X02_0X06.MinVoltageBatteryAssemblyNo);
            Assert.Equal(0x09, jTNE_0X02_0X06.MinVoltageSingleBatteryNo);
            Assert.Equal(0x08, jTNE_0X02_0X06.MinVoltageSingleBatteryValue);
        }
    }
}
