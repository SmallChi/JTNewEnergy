using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;
using JTNE.Protocol.Enums;

namespace JTNE.Protocol.Test
{
    public class JTNEPackageTest
    {
        [Fact]
        public void Test1()
        {
            var hex = "23 23 05 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 08 12 06 08 12 06 3A 00 01 E9".ToHexBytes();
            var package = JTNESerializer.Deserialize(hex);
            Assert.Equal("LGHC4V1D3HE202652", package.VIN);
            Assert.Equal(JTNEAskId.CMD.ToByteValue(), package.AskId);
            Assert.Equal((ushort)8, package.DataUnitLength);
            Assert.Equal(0x01, package.EncryptMethod);
            Assert.Equal(JTNEMsgId.platformlogin.ToByteValue(), package.MsgId);
        }
    }
}
