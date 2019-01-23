using JTNE.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Enums;
using JTNE.Protocol.MessageBody;

namespace JTNE.Protocol.Test.Package
{
    public class JTNE_0x07_PackageTest
    {
        [Fact]
        public void Test1()
        {
            JTNEPackage jTNEPackage = new JTNEPackage();
            jTNEPackage.AskId = JTNEAskId.CMD.ToByteValue();
            jTNEPackage.MsgId = JTNEMsgId.heartbeat.ToByteValue();
            jTNEPackage.VIN = "123456789";
            var hex = JTNESerializer.Serialize(jTNEPackage).ToHexString();
            Assert.Equal("232307FE3132333435363738390000000000000000010000C9", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "232307FE3132333435363738390000000000000000010000C9".ToHexBytes();
            JTNEPackage jTNEPackage = JTNESerializer.Deserialize(data);
            Assert.Equal(JTNEAskId.CMD.ToByteValue(), jTNEPackage.AskId);
            Assert.Equal(JTNEMsgId.heartbeat.ToByteValue(), jTNEPackage.MsgId);
            Assert.Equal("123456789", jTNEPackage.VIN);
            Assert.Null(jTNEPackage.Bodies);
        }
    }
}
