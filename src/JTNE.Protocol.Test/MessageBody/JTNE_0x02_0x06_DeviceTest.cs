using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x06_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x06_Device jTNE_0X02_0X06_Device = new JTNE_0x02_0x06_Device();
            jTNE_0X02_0X06_Device.MaxTempBatteryAssemblyNo = 0x12;
            jTNE_0X02_0X06_Device.MaxTempProbeBatteryNo = 0x32;
            jTNE_0X02_0X06_Device.MaxTempProbeBatteryValue = 0x42;
            jTNE_0X02_0X06_Device.MaxVoltageBatteryAssemblyNo = 0x11;
            jTNE_0X02_0X06_Device.MaxVoltageSingleBatteryNo = 0x15;
            jTNE_0X02_0X06_Device.MaxVoltageSingleBatteryValue = 123;
            jTNE_0X02_0X06_Device.MinTempBatteryAssemblyNo = 0x32;
            jTNE_0X02_0X06_Device.MinTempProbeBatteryNo = 0x11;
            jTNE_0X02_0X06_Device.MinTempProbeBatteryValue = 0x06;
            jTNE_0X02_0X06_Device.MinVoltageBatteryAssemblyNo = 0x07;
            jTNE_0X02_0X06_Device.MinVoltageSingleBatteryNo = 0x09;
            jTNE_0X02_0X06_Device.MinVoltageSingleBatteryValue = 0x08;
            var hex = JTNESerializer_Device.Serialize(jTNE_0X02_0X06_Device).ToHexString();
            Assert.Equal("061115007B07090008321242113206", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "061115007B07090008321242113206".ToHexBytes();
            JTNE_0x02_0x06_Device jTNE_0X02_0X06_Device = JTNESerializer_Device.Deserialize<JTNE_0x02_0x06_Device>(data);
            Assert.Equal(0x12, jTNE_0X02_0X06_Device.MaxTempBatteryAssemblyNo);
            Assert.Equal(0x32, jTNE_0X02_0X06_Device.MaxTempProbeBatteryNo);
            Assert.Equal(0x42, jTNE_0X02_0X06_Device.MaxTempProbeBatteryValue);
            Assert.Equal(0x11, jTNE_0X02_0X06_Device.MaxVoltageBatteryAssemblyNo);
            Assert.Equal(0x15, jTNE_0X02_0X06_Device.MaxVoltageSingleBatteryNo);
            Assert.Equal(123, jTNE_0X02_0X06_Device.MaxVoltageSingleBatteryValue);
            Assert.Equal(0x11, jTNE_0X02_0X06_Device.MinTempProbeBatteryNo);
            Assert.Equal(0x06, jTNE_0X02_0X06_Device.MinTempProbeBatteryValue);
            Assert.Equal(0x07, jTNE_0X02_0X06_Device.MinVoltageBatteryAssemblyNo);
            Assert.Equal(0x09, jTNE_0X02_0X06_Device.MinVoltageSingleBatteryNo);
            Assert.Equal(0x08, jTNE_0X02_0X06_Device.MinVoltageSingleBatteryValue);
        }
    }
}
