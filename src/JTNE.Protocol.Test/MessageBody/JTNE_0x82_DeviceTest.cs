using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;
using System.Linq;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x82_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x82_Device jTNE_0X82_Device = new JTNE_0x82_Device();
            jTNE_0X82_Device.ControlTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X82_Device.ParamID =0x02;
            var hex = JTNESerializer_Device.Serialize(jTNE_0X82_Device).ToHexString();
            Assert.Equal("13011617373802", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "13011617373802".ToHexBytes();
            JTNE_0x82_Device jTNE_0X82_Device = JTNESerializer_Device.Deserialize<JTNE_0x82_Device>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X82_Device.ControlTime);
            Assert.Equal(0x02, jTNE_0X82_Device.ParamID);
        }

        [Fact]
        public void Test3()
        {
            JTNE_0x82_Device jTNE_0X82_Device = new JTNE_0x82_Device();
            jTNE_0X82_Device.ControlTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X82_Device.ParamID = 0x01;
            jTNE_0X82_Device.Parameter = new JTNE_0x82_0x01_Device {
                UpgradeCommand = new Metadata.UpgradeCommand {
                  DialName="TK",
                   DialUserName="TKUser",
                    DialUserPwd="TKPwd",
                     FirmwareVersion="1.0",
                      HardwareVersion="2.0",
                       ManufacturerID= "ManufacturerName",
                        ServerAddress="http://www.baidu.com:8383",
                          ServerUrl= JTNEGlobalConfigs.Instance.Encoding.GetBytes("bd.com"),
                           ServerPort=8383,
                            ConnectTimeLimit=10
                }
            };
            var hex = JTNESerializer_Device.Serialize(jTNE_0X82_Device).ToHexString();
            Assert.Equal("13011617373801687474703A2F2F7777772E62616964752E636F6D3A383338333B544B3B544B557365723B544B5077643B62642E636F6D3B383338333B4D616E7566616374757265724E616D653B322E303B312E303B3130", hex);
        }

        [Fact]
        public void Test4()
        {
            var data = "13011617373801687474703A2F2F7777772E62616964752E636F6D3A383338333B544B3B544B557365723B544B5077643B62642E636F6D3B383338333B4D616E7566616374757265724E616D653B322E303B312E303B3130".ToHexBytes();
            JTNE_0x82_Device jTNE_0X82_Device = JTNESerializer_Device.Deserialize<JTNE_0x82_Device>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X82_Device.ControlTime);
            Assert.Equal(0x01, jTNE_0X82_Device.ParamID);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new JTNE_0x82_0x01_Device
            {
                UpgradeCommand = new Metadata.UpgradeCommand
                {
                    DialName = "TK",
                    DialUserName = "TKUser",
                    DialUserPwd = "TKPwd",
                    FirmwareVersion = "1.0",
                    HardwareVersion = "2.0",
                    ManufacturerID = "ManufacturerName",
                    ServerAddress = "http://www.baidu.com:8383",
                    ServerUrl = JTNEGlobalConfigs.Instance.Encoding.GetBytes("bd.com"),
                    ServerPort = 8383,
                    ConnectTimeLimit = 10
                }
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0X82_Device.Parameter));
        }

        [Fact]
        public void Test5()
        {
            JTNE_0x82_Device jTNE_0X82_Device = new JTNE_0x82_Device();
            jTNE_0X82_Device.ControlTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X82_Device.ParamID = 0x06;
            jTNE_0X82_Device.Parameter = new JTNE_0x82_0x06_Device
            {
              AlarmCommand=new Metadata.AlarmCommand {
                   AlarmLevel= Enums.JTNEAlarmLevel.一级报警
              }
            };
            var hex = JTNESerializer_Device.Serialize(jTNE_0X82_Device).ToHexString();
            Assert.Equal("1301161737380601", hex);
        }

        [Fact]
        public void Test6()
        {
            var data = "1301161737380601".ToHexBytes();
            JTNE_0x82_Device jTNE_0X82_Device = JTNESerializer_Device.Deserialize<JTNE_0x82_Device>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X82_Device.ControlTime);
            Assert.Equal(0x06, jTNE_0X82_Device.ParamID);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new JTNE_0x82_0x06_Device
            {
                AlarmCommand = new Metadata.AlarmCommand
                {
                    AlarmLevel = Enums.JTNEAlarmLevel.一级报警
                }
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0X82_Device.Parameter));
        }
    }
}
