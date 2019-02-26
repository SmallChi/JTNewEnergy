using JTNE.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Enums;
using JTNE.Protocol.MessageBody;

namespace JTNE.Protocol.Test.Package
{
    public class JTNE_0x04_Package_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNEPackage_Device jTNEPackage_Device = new JTNEPackage_Device();
            jTNEPackage_Device.AskId = JTNEAskId.CMD.ToByteValue();
            jTNEPackage_Device.MsgId = JTNEMsgId_Device.loginout.ToByteValue();
            jTNEPackage_Device.VIN = "123456789";
            JTNE_0x04_Device jTNE_0X04_Device = new JTNE_0x04_Device();
            jTNE_0X04_Device.LogoutTime = DateTime.Parse("2019-01-23 23:55:56");
            jTNE_0X04_Device.LogoutNum = 1;
            jTNEPackage_Device.Bodies = jTNE_0X04_Device;
            var hex = JTNESerializer_Device.Serialize(jTNEPackage_Device).ToHexString();
            Assert.Equal("232304FE31323334353637383900000000000000000100081301171737380001DE", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "232304FE31323334353637383900000000000000000100081301171737380001DE".ToHexBytes();
            JTNEPackage_Device jTNEPackage_Device = JTNESerializer_Device.Deserialize(data);
            Assert.Equal(JTNEAskId.CMD.ToByteValue(), jTNEPackage_Device.AskId);
            Assert.Equal(JTNEMsgId_Device.loginout.ToByteValue(), jTNEPackage_Device.MsgId);
            Assert.Equal("123456789", jTNEPackage_Device.VIN);
            JTNE_0x04_Device jTNE_0X04_Device = jTNEPackage_Device.Bodies as JTNE_0x04_Device;
            Assert.Equal(DateTime.Parse("2019-01-23 23:55:56"), jTNE_0X04_Device.LogoutTime);
            Assert.Equal(1, jTNE_0X04_Device.LogoutNum);
        }
    }
}
