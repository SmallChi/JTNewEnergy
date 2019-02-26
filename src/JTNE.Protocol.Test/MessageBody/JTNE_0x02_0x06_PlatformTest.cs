using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x06_PlatformTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x06_Platform jTNE_0X02_0X06_Platform = new JTNE_0x02_0x06_Platform();
            jTNE_0X02_0X06_Platform.MaxTempBatteryAssemblyNo = 0x12;
            jTNE_0X02_0X06_Platform.MaxTempProbeBatteryNo = 0x32;
            jTNE_0X02_0X06_Platform.MaxTempProbeBatteryValue = 0x42;
            jTNE_0X02_0X06_Platform.MaxVoltageBatteryAssemblyNo = 0x11;
            jTNE_0X02_0X06_Platform.MaxVoltageSingleBatteryNo = 0x15;
            jTNE_0X02_0X06_Platform.MaxVoltageSingleBatteryValue = 123;
            jTNE_0X02_0X06_Platform.MinTempBatteryAssemblyNo = 0x32;
            jTNE_0X02_0X06_Platform.MinTempProbeBatteryNo = 0x11;
            jTNE_0X02_0X06_Platform.MinTempProbeBatteryValue = 0x06;
            jTNE_0X02_0X06_Platform.MinVoltageBatteryAssemblyNo = 0x07;
            jTNE_0X02_0X06_Platform.MinVoltageSingleBatteryNo = 0x09;
            jTNE_0X02_0X06_Platform.MinVoltageSingleBatteryValue = 0x08;
            var hex = JTNESerializer_Platform.Serialize(jTNE_0X02_0X06_Platform).ToHexString();
            Assert.Equal("061115007B07090008321242113206", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "061115007B07090008321242113206".ToHexBytes();
            JTNE_0x02_0x06_Platform jTNE_0X02_0X06_Platform = JTNESerializer_Platform.Deserialize<JTNE_0x02_0x06_Platform>(data);
            Assert.Equal(0x12, jTNE_0X02_0X06_Platform.MaxTempBatteryAssemblyNo);
            Assert.Equal(0x32, jTNE_0X02_0X06_Platform.MaxTempProbeBatteryNo);
            Assert.Equal(0x42, jTNE_0X02_0X06_Platform.MaxTempProbeBatteryValue);
            Assert.Equal(0x11, jTNE_0X02_0X06_Platform.MaxVoltageBatteryAssemblyNo);
            Assert.Equal(0x15, jTNE_0X02_0X06_Platform.MaxVoltageSingleBatteryNo);
            Assert.Equal(123, jTNE_0X02_0X06_Platform.MaxVoltageSingleBatteryValue);
            Assert.Equal(0x11, jTNE_0X02_0X06_Platform.MinTempProbeBatteryNo);
            Assert.Equal(0x06, jTNE_0X02_0X06_Platform.MinTempProbeBatteryValue);
            Assert.Equal(0x07, jTNE_0X02_0X06_Platform.MinVoltageBatteryAssemblyNo);
            Assert.Equal(0x09, jTNE_0X02_0X06_Platform.MinVoltageSingleBatteryNo);
            Assert.Equal(0x08, jTNE_0X02_0X06_Platform.MinVoltageSingleBatteryValue);
        }
    }
}
