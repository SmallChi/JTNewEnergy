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
    public class JTNE_0x80Reply_CustomBody_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x81CustomBody(0x80, typeof(JTNE_0x80Reply_0x80_Device));
            JTNEGlobalConfigs.Instance.Register_JTNE0x81CustomBody(0x81, typeof(JTNE_0x80Reply_0x81_Device));
            JTNEGlobalConfigs.Instance.Register_JTNE0x81CustomDepenedBody(0x81, 0x80);

            JTNE_0x80Reply_Device jTNE_0x80Reply = new JTNE_0x80Reply_Device();
            JTNE_0x81_Device jTNE_0X81_Device = new JTNE_0x81_Device {
                 OperateTime= DateTime.Parse("2019-01-22 23:55:56"),
                  ParamNum=2,
                ParamList = new List<JTNE_0x81_Body_Device> {
                new JTNE_0x80Reply_0x80_Device{
                       ParamValue=6
                },
                new JTNE_0x80Reply_0x81_Device{
                     ParamLength=6,
                      ParamValue=new byte[]{ 1,2,3,4,5,6 }
                }
            }
            };
            jTNE_0x80Reply.JTNE_Reply0x80_Device = jTNE_0X81_Device;
            var hex = JTNESerializer_Device.Serialize(jTNE_0x80Reply).ToHexString();
            Assert.Equal("13011617373802800681010203040506", hex);
        }
        [Fact]
        public void Test1_1()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x81CustomBody(0x80, typeof(JTNE_0x80Reply_0x80_Device));
            JTNEGlobalConfigs.Instance.Register_JTNE0x81CustomBody(0x81, typeof(JTNE_0x80Reply_0x81_Device));
            JTNEGlobalConfigs.Instance.Register_JTNE0x81CustomDepenedBody(0x81, 0x80);

            var data = "13011617373802800681010203040506".ToHexBytes();
            JTNE_0x80Reply_Device jTNE_0x80Reply_Device = JTNESerializer_Device.Deserialize<JTNE_0x80Reply_Device>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0x80Reply_Device.JTNE_Reply0x80_Device.OperateTime);
            Assert.Equal(jTNE_0x80Reply_Device.JTNE_Reply0x80_Device.ParamList.Count, jTNE_0x80Reply_Device.JTNE_Reply0x80_Device.ParamNum);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new List<JTNE_0x81_Body_Device> {
               new JTNE_0x80Reply_0x80_Device{
                       ParamValue=6
                },
                new JTNE_0x80Reply_0x81_Device{
                     ParamLength=6,
                      ParamValue=new byte[]{ 1,2,3,4,5,6 }
                }
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0x80Reply_Device.JTNE_Reply0x80_Device.ParamList));
        }
    }
    [JTNEFormatter(typeof(JTNE_0x80Reply_0x80_Device_Formatter))]
    public class JTNE_0x80Reply_0x80_Device : JTNE_0x81_Body_Device
    {
        public override byte ParamId { get; set; }= 0x80;
        public override byte ParamLength { get; set; } = 1;
        public byte ParamValue { get; set; }
    }
    [JTNEFormatter(typeof(JTNE_0x80Reply_0x81_Device_Formatter))]
    public class JTNE_0x80Reply_0x81_Device : JTNE_0x81_Body_Device
    {
        public override byte ParamId { get; set; } = 0x81;
        public override byte ParamLength { get; set; }
        public byte[] ParamValue { get; set; }
    }

    public class JTNE_0x80Reply_0x80_Device_Formatter : IJTNEFormatter<JTNE_0x80Reply_0x80_Device>
    {
        public JTNE_0x80Reply_0x80_Device Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x80Reply_0x80_Device jTNE_0x80Reply_0x80_Device = new JTNE_0x80Reply_0x80_Device();
            jTNE_0x80Reply_0x80_Device.ParamValue = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNE_0x80Reply_0x80_Device;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x80Reply_0x80_Device value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.ParamValue);
            return offset;
        }
    }
    public class JTNE_0x80Reply_0x81_Device_Formatter : IJTNEFormatter<JTNE_0x80Reply_0x81_Device>
    {
        public JTNE_0x80Reply_0x81_Device Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x80Reply_0x81_Device jTNE_0x80Reply_0x80Reply_Device = new JTNE_0x80Reply_0x81_Device();
            jTNE_0x80Reply_0x80Reply_Device.ParamValue = JTNEBinaryExtensions.ReadBytesLittle(bytes, ref offset);
            jTNE_0x80Reply_0x80Reply_Device.ParamLength = (byte)bytes.Length;
            readSize = offset;
            return jTNE_0x80Reply_0x80Reply_Device;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x80Reply_0x81_Device value)
        {
            offset += JTNEBinaryExtensions.WriteBytesLittle(bytes, offset, value.ParamValue);
            return offset;
        }
    }
}
