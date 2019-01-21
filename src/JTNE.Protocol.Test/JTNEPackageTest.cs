using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test
{
    public class JTNEPackageTest
    {
        [Fact]
        public void Test1()
        {
            var hex = "23 23 05 FE 4C 47 48 43 34 56 31 44 33 48 45 32 30 32 36 35 32 01 00 08 12 06 08 12 06 3A 00 01 E9".ToHexBytes();
            var package=JTNESerializer.Deserialize(hex);
        }
    }
}
