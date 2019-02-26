using JTNE.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Enums;
using JTNE.Protocol.MessageBody;

namespace JTNE.Protocol.Test.Package
{
    public class JTNE_0x07_Package_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNEPackage_Device jTNEPackage_Device = new JTNEPackage_Device();
            jTNEPackage_Device.AskId = JTNEAskId.CMD.ToByteValue();
            jTNEPackage_Device.MsgId = JTNEMsgId_Device.heartbeat.ToByteValue();
            jTNEPackage_Device.VIN = "123456789";
            var hex = JTNESerializer_Device.Serialize(jTNEPackage_Device).ToHexString();
            Assert.Equal("232307FE3132333435363738390000000000000000010000C9", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "232307FE3132333435363738390000000000000000010000C9".ToHexBytes();
            JTNEPackage_Device jTNEPackage_Device = JTNESerializer_Device.Deserialize(data);
            Assert.Equal(JTNEAskId.CMD.ToByteValue(), jTNEPackage_Device.AskId);
            Assert.Equal(JTNEMsgId_Device.heartbeat.ToByteValue(), jTNEPackage_Device.MsgId);
            Assert.Equal("123456789", jTNEPackage_Device.VIN);
            Assert.Null(jTNEPackage_Device.Bodies);
        }
    }
}
