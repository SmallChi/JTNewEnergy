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
    public class JTNE_0x82_CustomBody_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x82CustomBody(0x80, typeof(JTNE_0x82_0x80_Device));

            JTNE_0x82_Device jTNE_0X82_Device = new JTNE_0x82_Device();
            jTNE_0X82_Device.ControlTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X82_Device.ParamID = 0x80;
            jTNE_0X82_Device.Parameter = new JTNE_0x82_0x80_Device
            {
                ParamValue=100
            };
            var hex = JTNESerializer_Device.Serialize(jTNE_0X82_Device).ToHexString();
            Assert.Equal("1301161737388064", hex);
        }
        [Fact]
        public void Test1_1()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x82CustomBody(0x80, typeof(JTNE_0x82_0x80_Device));

            var data = "1301161737388064".ToHexBytes();
            JTNE_0x82_Device jTNE_0x82_Device = JTNESerializer_Device.Deserialize<JTNE_0x82_Device>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0x82_Device.ControlTime);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new JTNE_0x82_0x80_Device
            {
                ParamValue = 100
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0x82_Device.Parameter));
        }
    }
    [JTNEFormatter(typeof(JTNE_0x82_0x80_Device_Formatter))]
    public class JTNE_0x82_0x80_Device : JTNE_0x82_Body_Device
    {
        public override byte ParamId { get; set; }= 0x80;
        public override byte ParamLength { get; set; } = 1;
        public byte ParamValue { get; set; }
    }

    public class JTNE_0x82_0x80_Device_Formatter : IJTNEFormatter<JTNE_0x82_0x80_Device>
    {
        public JTNE_0x82_0x80_Device Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x82_0x80_Device jTNE_0x82_0x80_Device = new JTNE_0x82_0x80_Device();
            jTNE_0x82_0x80_Device.ParamValue = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNE_0x82_0x80_Device;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x82_0x80_Device value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.ParamValue);
            return offset;
        }
    }
}
