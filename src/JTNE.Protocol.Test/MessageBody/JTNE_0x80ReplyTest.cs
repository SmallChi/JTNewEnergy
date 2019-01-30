using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x80ReplyTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x80Reply jTNE_0x80Reply = new JTNE_0x80Reply();
            JTNE_0x81 jTNE_0X81 = new JTNE_0x81
            {
                OperateTime = DateTime.Parse("2019-01-22 23:55:56"),
                ParamNum = 1,
                ParamList = new List<JTNE_0x81_Body> {
                new JTNE_0x81_0x01{
                     ParamId=0x01,
                      ParamLength=2,
                       ParamValue=10
                }
            }
            };
            jTNE_0x80Reply.JTNE_Reply0x80 = jTNE_0X81;
            var hex = JTNESerializer.Serialize(jTNE_0x80Reply).ToHexString();
            Assert.Equal("1301161737380101000A", hex);
        }

        [Fact]
        public void Test1_1()
        {
            var data = "1301161737380101000A".ToHexBytes();
            JTNE_0x80Reply jTNE_0x80Reply = JTNESerializer.Deserialize<JTNE_0x80Reply>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0x80Reply.JTNE_Reply0x80.OperateTime);
            Assert.Equal(1, jTNE_0x80Reply.JTNE_Reply0x80.ParamNum);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject( new JTNE_0x81_0x01
            {
                ParamId = 0x01,
                ParamLength = 2,
                ParamValue = 10
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0x80Reply.JTNE_Reply0x80.ParamList[0]));
        }
        [Fact]
        public void Test2()
        {
            JTNE_0x80Reply jTNE_0x80Reply = new JTNE_0x80Reply();
            JTNE_0x81 jTNE_0X81 = new JTNE_0x81
            {
                OperateTime = DateTime.Parse("2019-01-22 23:55:56"),
                ParamNum = 1,
                ParamList = new List<JTNE_0x81_Body> {
                new JTNE_0x81_0x02{
                     ParamId=0x02,
                      ParamLength=2,
                       ParamValue=20
                }
            }
            };
            jTNE_0x80Reply.JTNE_Reply0x80 = jTNE_0X81;
            var hex = JTNESerializer.Serialize(jTNE_0x80Reply).ToHexString();
            Assert.Equal("13011617373801020014", hex);
        }

        [Fact]
        public void Test2_1()
        {
            var data = "13011617373801020014".ToHexBytes();
            JTNE_0x80Reply jTNE_0x80Reply = JTNESerializer.Deserialize<JTNE_0x80Reply>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0x80Reply.JTNE_Reply0x80.OperateTime);
            Assert.Equal(1, jTNE_0x80Reply.JTNE_Reply0x80.ParamNum);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new JTNE_0x81_0x02
            {
                ParamId = 0x02,
                ParamLength = 2,
                ParamValue = 20
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0x80Reply.JTNE_Reply0x80.ParamList[0]));
        }
        [Fact]
        public void Test4()
        {
            JTNE_0x80Reply jTNE_0x80Reply = new JTNE_0x80Reply();
            JTNE_0x81 jTNE_0X81 = new JTNE_0x81
            {
                OperateTime = DateTime.Parse("2019-01-22 23:55:56"),
                 ParamNum=3,
                ParamList = new List<JTNE_0x81_Body> {
                new JTNE_0x81_0x04{
                       ParamValue=8
                },new JTNE_0x81_0x05{
                       ParamValue=new byte[]{ 1, 2, 3, 4, 5, 6, 7, 8 }
                },
                   new JTNE_0x81_0x06{
                       ParamValue=40
                }
            }
            };
            jTNE_0x80Reply.JTNE_Reply0x80 = jTNE_0X81;
            var hex = JTNESerializer.Serialize(jTNE_0x80Reply).ToHexString();
            Assert.Equal("130116173738030408050102030405060708060028", hex);
        }

        [Fact]
        public void Test4_1()
        {
            var data = "130116173738030408050102030405060708060028".ToHexBytes();
            JTNE_0x80Reply jTNE_0x80Reply = JTNESerializer.Deserialize<JTNE_0x80Reply>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0x80Reply.JTNE_Reply0x80.OperateTime);
            Assert.Equal(jTNE_0x80Reply.JTNE_Reply0x80.ParamList.Count, jTNE_0x80Reply.JTNE_Reply0x80.ParamNum);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new List<JTNE_0x81_Body> {
                new JTNE_0x81_0x04{
                       ParamValue=8
                },new JTNE_0x81_0x05{
                       ParamValue=new byte[]{1,2,3,4,5,6,7,8 },
                        ParamLength=8
                },   new JTNE_0x81_0x06{
                       ParamValue=40
                }
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0x80Reply.JTNE_Reply0x80.ParamList));
        }


        [Fact]
        public void Test5()
        {
            JTNE_0x80Reply jTNE_0x80Reply = new JTNE_0x80Reply();
            JTNE_0x81 jTNE_0X81 = new JTNE_0x81
            {
                 OperateTime = DateTime.Parse("2019-01-22 23:55:56"),
                  ParamNum=3,
                ParamList = new List<JTNE_0x81_Body> {
                new JTNE_0x81_0x0D{
                       ParamValue=8
                },new JTNE_0x81_0x0E{
                       ParamValue=new byte[]{ 1, 2, 3, 4, 5, 6, 7, 8 }
                },
                   new JTNE_0x81_0x0F{
                       ParamValue=40
                }
            }
            };
            jTNE_0x80Reply.JTNE_Reply0x80 = jTNE_0X81;
            var hex = JTNESerializer.Serialize(jTNE_0x80Reply).ToHexString();
            Assert.Equal("130116173738030D080E01020304050607080F0028", hex);
        }

        [Fact]
        public void Test5_1()
        {
            var data = "130116173738030D080E01020304050607080F0028".ToHexBytes();
            JTNE_0x80Reply jTNE_0x80Reply = JTNESerializer.Deserialize<JTNE_0x80Reply>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0x80Reply.JTNE_Reply0x80.OperateTime);
            Assert.Equal(jTNE_0x80Reply.JTNE_Reply0x80.ParamList.Count, jTNE_0x80Reply.JTNE_Reply0x80.ParamNum);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new List<JTNE_0x81_Body> {
                new JTNE_0x81_0x0D{
                       ParamValue=8
                },new JTNE_0x81_0x0E{
                       ParamValue=new byte[]{1,2,3,4,5,6,7,8 },
                         ParamLength=8
                },   new JTNE_0x81_0x0F{
                       ParamValue=40
                }
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0x80Reply.JTNE_Reply0x80.ParamList));
        }


        [Fact]
        public void Test3()
        {
            JTNE_0x80Reply jTNE_0x80Reply = new JTNE_0x80Reply();
            JTNE_0x81 jTNE_0X81 = new JTNE_0x81 {
                 OperateTime= DateTime.Parse("2019-01-22 23:55:56"),
                  ParamNum=1,
                   ParamList = new List<JTNE_0x81_Body> {
                new JTNE_0x81_0x03{
                     ParamId=0x03,
                      ParamLength=2,
                       ParamValue=30
                }
            }
            };
            jTNE_0x80Reply.JTNE_Reply0x80 = jTNE_0X81;
            var hex = JTNESerializer.Serialize(jTNE_0x80Reply).ToHexString();
            Assert.Equal("1301161737380103001E", hex);
        }

        [Fact]
        public void Test3_1()
        {
            var data = "1301161737380103001E".ToHexBytes();
            JTNE_0x80Reply jTNE_0x80Reply = JTNESerializer.Deserialize<JTNE_0x80Reply>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0x80Reply.JTNE_Reply0x80.OperateTime);
            Assert.Equal(1, jTNE_0x80Reply.JTNE_Reply0x80.ParamNum);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new JTNE_0x81_0x03
            {
                ParamId = 0x03,
                ParamLength = 2,
                ParamValue = 30
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0x80Reply.JTNE_Reply0x80.ParamList[0]));
        }
        [Fact]
        public void TestAll()
        {
            JTNE_0x80Reply jTNE_0x80Reply = new JTNE_0x80Reply();
            JTNE_0x81 jTNE_0X81 = new JTNE_0x81 {
                 OperateTime = DateTime.Parse("2019-01-22 23:55:56"),
                  ParamNum=12,
                ParamList = new List<JTNE_0x81_Body> {
                new JTNE_0x81_0x01{
                     ParamValue=10
                },
              new JTNE_0x81_0x02{
                     ParamValue=20
                },
                new JTNE_0x81_0x03{
                       ParamValue=30
                },
                new JTNE_0x81_0x06{
                       ParamValue=40
                },
                new JTNE_0x81_0x07{
                       ParamValue="abcde"
                },
                new JTNE_0x81_0x08{
                       ParamValue="12345"
                },
                new JTNE_0x81_0x09{
                       ParamValue=50
                },
                new JTNE_0x81_0x0A{
                       ParamValue=60
                },
                new JTNE_0x81_0x0B{
                       ParamValue=70
                },
                new JTNE_0x81_0x0C{
                       ParamValue=80
                },
                new JTNE_0x81_0x0F{
                       ParamValue=90
                },
                new JTNE_0x81_0x10{
                       ParamValue=0x01
                }
            }
            };
            jTNE_0x80Reply.JTNE_Reply0x80 = jTNE_0X81;
            var hex = JTNESerializer.Serialize(jTNE_0x80Reply).ToHexString();
            Assert.Equal("1301161737380C01000A02001403001E06002807616263646508313233343509320A003C0B00460C500F005A1001", hex);
        }

        [Fact]
        public void TestAll_1()
        {
            var data = "1301161737380C01000A02001403001E06002807616263646508313233343509320A003C0B00460C500F005A1001".ToHexBytes();
            JTNE_0x80Reply jTNE_0x80Reply = JTNESerializer.Deserialize<JTNE_0x80Reply>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0x80Reply.JTNE_Reply0x80.OperateTime);
            Assert.Equal(12, jTNE_0x80Reply.JTNE_Reply0x80.ParamNum);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new List<JTNE_0x81_Body> {
                new JTNE_0x81_0x01{
                     ParamValue=10
                },
              new JTNE_0x81_0x02{
                     ParamValue=20
                },
                new JTNE_0x81_0x03{
                       ParamValue=30
                },
                new JTNE_0x81_0x06{
                       ParamValue=40
                },
                new JTNE_0x81_0x07{
                       ParamValue="abcde"
                },
                new JTNE_0x81_0x08{
                       ParamValue="12345"
                },
                new JTNE_0x81_0x09{
                       ParamValue=50
                },
                new JTNE_0x81_0x0A{
                       ParamValue=60
                },
                new JTNE_0x81_0x0B{
                       ParamValue=70
                },
                new JTNE_0x81_0x0C{
                       ParamValue=80
                },
                new JTNE_0x81_0x0F{
                       ParamValue=90
                },
                new JTNE_0x81_0x10{
                       ParamValue=0x01
                }
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0x80Reply.JTNE_Reply0x80.ParamList));
        }
    }
}
