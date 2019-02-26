using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x81_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x81_Device jTNE_0X81_Device = new JTNE_0x81_Device();
            jTNE_0X81_Device.OperateTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X81_Device.ParamNum = 1;
            jTNE_0X81_Device.ParamList = new List<JTNE_0x81_Body_Device> {
                new JTNE_0x81_0x01_Device{
                     ParamId=0x01,
                      ParamLength=2,
                       ParamValue=10
                }
            };
            var hex = JTNESerializer_Device.Serialize(jTNE_0X81_Device).ToHexString();
            Assert.Equal("1301161737380101000A", hex);
        }

        [Fact]
        public void Test1_1()
        {
            var data = "1301161737380101000A".ToHexBytes();
            JTNE_0x81_Device jTNE_0X81_Device = JTNESerializer_Device.Deserialize<JTNE_0x81_Device>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X81_Device.OperateTime);
            Assert.Equal(1, jTNE_0X81_Device.ParamNum);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject( new JTNE_0x81_0x01_Device
            {
                ParamId = 0x01,
                ParamLength = 2,
                ParamValue = 10
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0X81_Device.ParamList[0] ));
        }
        [Fact]
        public void Test2()
        {
            JTNE_0x81_Device jTNE_0X81_Device = new JTNE_0x81_Device();
            jTNE_0X81_Device.OperateTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X81_Device.ParamNum = 1;
            jTNE_0X81_Device.ParamList = new List<JTNE_0x81_Body_Device> {
                new JTNE_0x81_0x02_Device{
                     ParamId=0x02,
                      ParamLength=2,
                       ParamValue=20
                }
            };
            var hex = JTNESerializer_Device.Serialize(jTNE_0X81_Device).ToHexString();
            Assert.Equal("13011617373801020014", hex);
        }

        [Fact]
        public void Test2_1()
        {
            var data = "13011617373801020014".ToHexBytes();
            JTNE_0x81_Device jTNE_0X81_Device = JTNESerializer_Device.Deserialize<JTNE_0x81_Device>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X81_Device.OperateTime);
            Assert.Equal(1, jTNE_0X81_Device.ParamNum);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new JTNE_0x81_0x02_Device
            {
                ParamId = 0x02,
                ParamLength = 2,
                ParamValue = 20
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0X81_Device.ParamList[0]));
        }
        [Fact]
        public void Test4()
        {
            JTNE_0x81_Device jTNE_0X81_Device = new JTNE_0x81_Device();
            jTNE_0X81_Device.OperateTime = DateTime.Parse("2019-01-22 23:55:56");         
            jTNE_0X81_Device.ParamList = new List<JTNE_0x81_Body_Device> {
                new JTNE_0x81_0x04_Device{
                       ParamValue=8
                },new JTNE_0x81_0x05_Device{
                       ParamValue=new byte[]{ 1, 2, 3, 4, 5, 6, 7, 8 }
                },
                   new JTNE_0x81_0x06_Device{
                       ParamValue=40
                }
            };
            jTNE_0X81_Device.ParamNum =(byte)jTNE_0X81_Device.ParamList.Count;
            var hex = JTNESerializer_Device.Serialize(jTNE_0X81_Device).ToHexString();
            Assert.Equal("130116173738030408050102030405060708060028", hex);
        }

        [Fact]
        public void Test4_1()
        {
            var data = "130116173738030408050102030405060708060028".ToHexBytes();
            JTNE_0x81_Device jTNE_0X81_Device = JTNESerializer_Device.Deserialize<JTNE_0x81_Device>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X81_Device.OperateTime);
            Assert.Equal(jTNE_0X81_Device.ParamList.Count, jTNE_0X81_Device.ParamNum);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new List<JTNE_0x81_Body_Device> {
                new JTNE_0x81_0x04_Device{
                       ParamValue=8
                },new JTNE_0x81_0x05_Device{
                       ParamValue=new byte[]{1,2,3,4,5,6,7,8 },
                        ParamLength=8
                },   new JTNE_0x81_0x06_Device{
                       ParamValue=40
                }
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0X81_Device.ParamList));
        }


        [Fact]
        public void Test5()
        {
            JTNE_0x81_Device jTNE_0X81_Device = new JTNE_0x81_Device();
            jTNE_0X81_Device.OperateTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X81_Device.ParamList = new List<JTNE_0x81_Body_Device> {
                new JTNE_0x81_0x0D_Device{
                       ParamValue=8
                },new JTNE_0x81_0x0E_Device{
                       ParamValue=new byte[]{ 1, 2, 3, 4, 5, 6, 7, 8 }
                },
                   new JTNE_0x81_0x0F_Device{
                       ParamValue=40
                }
            };
            jTNE_0X81_Device.ParamNum = (byte)jTNE_0X81_Device.ParamList.Count;
            var hex = JTNESerializer_Device.Serialize(jTNE_0X81_Device).ToHexString();
            Assert.Equal("130116173738030D080E01020304050607080F0028", hex);
        }

        [Fact]
        public void Test5_1()
        {
            var data = "130116173738030D080E01020304050607080F0028".ToHexBytes();
            JTNE_0x81_Device jTNE_0X81_Device = JTNESerializer_Device.Deserialize<JTNE_0x81_Device>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X81_Device.OperateTime);
            Assert.Equal(jTNE_0X81_Device.ParamList.Count, jTNE_0X81_Device.ParamNum);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new List<JTNE_0x81_Body_Device> {
                new JTNE_0x81_0x0D_Device{
                       ParamValue=8
                },new JTNE_0x81_0x0E_Device{
                       ParamValue=new byte[]{1,2,3,4,5,6,7,8 },
                         ParamLength=8
                },   new JTNE_0x81_0x0F_Device{
                       ParamValue=40
                }
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0X81_Device.ParamList));
        }


        [Fact]
        public void Test3()
        {
            JTNE_0x81_Device jTNE_0X81_Device = new JTNE_0x81_Device();
            jTNE_0X81_Device.OperateTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X81_Device.ParamNum = 1;
            jTNE_0X81_Device.ParamList = new List<JTNE_0x81_Body_Device> {
                new JTNE_0x81_0x03_Device{
                     ParamId=0x03,
                      ParamLength=2,
                       ParamValue=30
                }
            };
            var hex = JTNESerializer_Device.Serialize(jTNE_0X81_Device).ToHexString();
            Assert.Equal("1301161737380103001E", hex);
        }

        [Fact]
        public void Test3_1()
        {
            var data = "1301161737380103001E".ToHexBytes();
            JTNE_0x81_Device jTNE_0X81_Device = JTNESerializer_Device.Deserialize<JTNE_0x81_Device>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X81_Device.OperateTime);
            Assert.Equal(1, jTNE_0X81_Device.ParamNum);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new JTNE_0x81_0x03_Device
            {
                ParamId = 0x03,
                ParamLength = 2,
                ParamValue = 30
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0X81_Device.ParamList[0]));
        }
        [Fact]
        public void TestAll()
        {
            JTNE_0x81_Device jTNE_0X81_Device = new JTNE_0x81_Device();
            jTNE_0X81_Device.OperateTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X81_Device.ParamNum = 12;
            jTNE_0X81_Device.ParamList = new List<JTNE_0x81_Body_Device> {
                new JTNE_0x81_0x01_Device{
                     ParamValue=10
                },
              new JTNE_0x81_0x02_Device{
                     ParamValue=20
                },
                new JTNE_0x81_0x03_Device{
                       ParamValue=30
                },
                new JTNE_0x81_0x06_Device{
                       ParamValue=40
                },
                new JTNE_0x81_0x07_Device{
                       ParamValue="abcde"
                },
                new JTNE_0x81_0x08_Device{
                       ParamValue="12345"
                },
                new JTNE_0x81_0x09_Device{
                       ParamValue=50
                },
                new JTNE_0x81_0x0A_Device{
                       ParamValue=60
                },
                new JTNE_0x81_0x0B_Device{
                       ParamValue=70
                },
                new JTNE_0x81_0x0C_Device{
                       ParamValue=80
                },
                new JTNE_0x81_0x0F_Device{
                       ParamValue=90
                },
                new JTNE_0x81_0x10_Device{
                       ParamValue=0x01
                }
            };
            var hex = JTNESerializer_Device.Serialize(jTNE_0X81_Device).ToHexString();
            Assert.Equal("1301161737380C01000A02001403001E06002807616263646508313233343509320A003C0B00460C500F005A1001", hex);
        }

        [Fact]
        public void TestAll_1()
        {
            var data = "1301161737380C01000A02001403001E06002807616263646508313233343509320A003C0B00460C500F005A1001".ToHexBytes();
            JTNE_0x81_Device jTNE_0X81_Device = JTNESerializer_Device.Deserialize<JTNE_0x81_Device>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X81_Device.OperateTime);
            Assert.Equal(12, jTNE_0X81_Device.ParamNum);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new List<JTNE_0x81_Body_Device> {
                new JTNE_0x81_0x01_Device{
                     ParamValue=10
                },
              new JTNE_0x81_0x02_Device{
                     ParamValue=20
                },
                new JTNE_0x81_0x03_Device{
                       ParamValue=30
                },
                new JTNE_0x81_0x06_Device{
                       ParamValue=40
                },
                new JTNE_0x81_0x07_Device{
                       ParamValue="abcde"
                },
                new JTNE_0x81_0x08_Device{
                       ParamValue="12345"
                },
                new JTNE_0x81_0x09_Device{
                       ParamValue=50
                },
                new JTNE_0x81_0x0A_Device{
                       ParamValue=60
                },
                new JTNE_0x81_0x0B_Device{
                       ParamValue=70
                },
                new JTNE_0x81_0x0C_Device{
                       ParamValue=80
                },
                new JTNE_0x81_0x0F_Device{
                       ParamValue=90
                },
                new JTNE_0x81_0x10_Device{
                       ParamValue=0x01
                }
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0X81_Device.ParamList));
        }
    }
}
