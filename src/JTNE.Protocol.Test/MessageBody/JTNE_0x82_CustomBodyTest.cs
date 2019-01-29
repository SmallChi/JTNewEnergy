using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;
using JTNE.Protocol.Formatters;
using JTNE.Protocol.Attributes;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x82_CustomBodyTest
    {
        [Fact]
        public void Test1()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x82CustomBody(0x80, typeof(JTNE_0x82_0x80));

            JTNE_0x82 jTNE_0X82 = new JTNE_0x82();
            jTNE_0X82.ControlTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X82.ParamID = 0x80;
            jTNE_0X82.Parameter = new JTNE_0x82_0x80
            {
                ParamValue=100
            };
            var hex = JTNESerializer.Serialize(jTNE_0X82).ToHexString();
            Assert.Equal("1301161737388064", hex);
        }
        [Fact]
        public void Test1_1()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x82CustomBody(0x80, typeof(JTNE_0x82_0x80));

            var data = "1301161737388064".ToHexBytes();
            JTNE_0x82 jTNE_0x82 = JTNESerializer.Deserialize<JTNE_0x82>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0x82.ControlTime);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new JTNE_0x82_0x80
            {
                ParamValue = 100
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0x82.Parameter));
        }
    }
    [JTNEFormatter(typeof(JTNE_0x82_0x80Formatter))]
    public class JTNE_0x82_0x80 : JTNE_0x82_Body
    {
        public override byte ParamId { get; set; }= 0x80;
        public override byte ParamLength { get; set; } = 1;
        public byte ParamValue { get; set; }
    }

    public class JTNE_0x82_0x80Formatter : IJTNEFormatter<JTNE_0x82_0x80>
    {
        public JTNE_0x82_0x80 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x82_0x80 jTNE_0x82_0x80 = new JTNE_0x82_0x80();
            jTNE_0x82_0x80.ParamValue = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNE_0x82_0x80;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x82_0x80 value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.ParamValue);
            return offset;
        }
    }
}
