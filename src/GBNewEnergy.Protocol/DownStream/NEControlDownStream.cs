using GBNewEnergy.Protocol.Enums;
using GBNewEnergy.Protocol.Extensions;
using GBNewEnergy.Protocol.NEProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.DownStream
{
    /// <summary>
    /// 车载终端控制命令
    /// </summary>
    public class NEControlDownStream : NEBodies
    {
        public NEControlDownStream(byte[] buffer, NEGlobalConfigs nEConfigs) : base(buffer, nEConfigs)
        {
        }

        public NEControlDownStream(INEProperties nEProperties, NEGlobalConfigs nEConfigs) : base(nEProperties, nEConfigs)
        {
        }
        /// <summary>
        /// 命令ID 只能发送一个
        /// </summary>
        public NEControlCmd CmdID { get; set; }
        /// <summary>
        /// 命令参数   没有内容则内容为空
        /// </summary>
        public string CmdParameter { get; set; }
        protected override void InitializeProperties(INEProperties nEProperties)
        {
            NEControlProperty nEControlProperty = (NEControlProperty)nEProperties;
            CmdID = nEControlProperty.CmdID;
            if (CmdID == NEControlCmd.remoteupdate)
            {
                CmdParameter = nEControlProperty.UpgradeParameter.ToString();
            }
            else if(CmdID == NEControlCmd.warning)
            {
                CmdParameter = nEControlProperty.AlarmParameter.nEAlarmLevel.ToString();
            }
        }

        protected override void InitializePropertiesFromBuffer()
        {
             CurrentDateTime = Buffer.ReadDateTimeLittle(0, 6);
            CmdID = (NEControlCmd)Buffer[6];
            switch (CmdID)
            {
                case NEControlCmd.remoteupdate:
                    CmdParameter = Buffer.ReadStringLittle(7, Buffer.Length - 8);//最后一位为校验码，不在参数列
                    break;
                case NEControlCmd.warning:
                    CmdParameter = ((NEAlarmLevel)Buffer[7]).ToString();
                    break;
                case NEControlCmd.unused:
                case NEControlCmd.shutdown:
                case NEControlCmd.reset:
                case NEControlCmd.restorefactorysettings:
                case NEControlCmd.interruptrequest:
                case NEControlCmd.OpenMonitoring:
                default:
                    break;
            }
        }


        protected override void ToBuffer()
        {
            if (CmdID == NEControlCmd.remoteupdate)
            {
                var contentLength = NEConfigs.NEEncoding.GetBytes(CmdParameter).Length;
                Buffer = new byte[6 + 1 + contentLength];
                Buffer.WriteLittle(CurrentDateTime, 0, 6);
                Buffer.WriteLittle(CmdID.ToByteValue(), 6);
                Buffer.WriteLittle(CmdParameter, 7);
            }
            else if (CmdID == NEControlCmd.warning) {
                Buffer = new byte[6 + 1 + 1];
                Buffer.WriteLittle(CurrentDateTime, 0, 6);
                Buffer.WriteLittle(CmdID.ToByteValue(), 6);
                Buffer.WriteLittle(CmdParameter.ToEnum<NEAlarmLevel>().ToByteValue(), 7);
            }
            else
            {
                Buffer = new byte[6 + 1];
                Buffer.WriteLittle(CurrentDateTime, 0, 6);
                Buffer.WriteLittle(CmdID.ToByteValue(), 6);
            }
        }
    }
}
