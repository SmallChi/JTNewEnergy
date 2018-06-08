using GBNewEnergy.Protocol.Enums;
using GBNewEnergy.Protocol.UpStream;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol
{
    public class NEBodiesFactory
    {
        /// <summary>
        /// 通过命令id获取数据体
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static NEBodies GetNEBodiesByMsgId(MsgId msgId,byte[] buf)
        {
            switch (msgId)
            {
                case MsgId.login:
                    return new NELoginUpStream(buf);
                case MsgId.loginout:
                    return new NELogoutUpStream(buf);
                default:
                    return null;
            }
        }
    }
}
