using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x82_0x01Formatter : IJTNEFormatter<JTNE_0x82_0x01>
    {
        public JTNE_0x82_0x01 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x82_0x01 jTNE_0x82_0x01 = new JTNE_0x82_0x01();
            string res = JTNEBinaryExtensions.ReadStringLittle(bytes, ref offset);
            string[] upgradeCommands = res.Split(';');
            jTNE_0x82_0x01.UpgradeCommand = new Metadata.UpgradeCommand();
            jTNE_0x82_0x01.UpgradeCommand.ServerAddress = upgradeCommands[0];
            jTNE_0x82_0x01.UpgradeCommand.DialName = upgradeCommands[1];
            jTNE_0x82_0x01.UpgradeCommand.DialUserName = upgradeCommands[2];
            jTNE_0x82_0x01.UpgradeCommand.DialUserPwd = upgradeCommands[3];
            jTNE_0x82_0x01.UpgradeCommand.ServerUrl = JTNEGlobalConfigs.Instance.Encoding.GetBytes(upgradeCommands[4]);
            if (ushort.TryParse(upgradeCommands[5], out ushort serverPort))
            {
                jTNE_0x82_0x01.UpgradeCommand.ServerPort = serverPort;
            }
            jTNE_0x82_0x01.UpgradeCommand.ManufacturerID = upgradeCommands[6];
            jTNE_0x82_0x01.UpgradeCommand.HardwareVersion = upgradeCommands[7];
            jTNE_0x82_0x01.UpgradeCommand.FirmwareVersion = upgradeCommands[8];   
            if (ushort.TryParse(upgradeCommands[9], out ushort connectTimeLimit)){
                jTNE_0x82_0x01.UpgradeCommand.ConnectTimeLimit = connectTimeLimit;
            }
            readSize = offset;
            return jTNE_0x82_0x01;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x82_0x01 value)
        {
            offset += JTNEBinaryExtensions.WriteStringLittle(bytes, offset, value.UpgradeCommand.ToString());
            return offset;
        }
    }
}
