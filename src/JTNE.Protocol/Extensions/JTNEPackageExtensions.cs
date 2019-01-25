using JTNE.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class JTNEPackageExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TJTNEBodies"></typeparam>
        /// <param name="msgId"></param>
        /// <param name="askId"></param>
        /// <param name="vin"></param>
        /// <param name="bodies"></param>
        /// <returns></returns>
        public static JTNEPackage Create<TJTNEBodies>(this JTNEMsgId msgId,string vin, JTNEAskId askId, TJTNEBodies bodies)
            where TJTNEBodies : JTNEBodies
        {
            JTNEPackage jTNEPackage = new JTNEPackage();
            jTNEPackage.AskId = askId.ToByteValue();
            jTNEPackage.MsgId = msgId.ToByteValue();
            jTNEPackage.Bodies = bodies;
            jTNEPackage.VIN = vin;
            return jTNEPackage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="vin"></param>
        /// <param name="askId"></param>
        /// <returns></returns>
        public static JTNEPackage Create(this JTNEMsgId msgId, string vin, JTNEAskId askId)
        {
            JTNEPackage jTNEPackage = new JTNEPackage();
            jTNEPackage.AskId = askId.ToByteValue();
            jTNEPackage.MsgId = msgId.ToByteValue();
            jTNEPackage.VIN = vin;
            return jTNEPackage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TJTNEBodies"></typeparam>
        /// <param name="msgId"></param>
        /// <param name="vin"></param>
        /// <param name="askId"></param>
        /// <param name="bodies"></param>
        /// <returns></returns>
        public static JTNEPackage CreateCustomMsgId<TJTNEBodies>(this byte msgId, string vin, JTNEAskId askId, TJTNEBodies bodies)
            where TJTNEBodies : JTNEBodies
        {
            JTNEPackage jTNEPackage = new JTNEPackage();
            jTNEPackage.AskId = askId.ToByteValue();
            jTNEPackage.MsgId = msgId;
            jTNEPackage.Bodies = bodies;
            jTNEPackage.VIN = vin;
            return jTNEPackage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="askId"></param>
        /// <param name="vin"></param>
        /// <returns></returns>
        public static JTNEPackage CreateCustomMsgId(this byte msgId, string vin, JTNEAskId askId)
        {
            JTNEPackage jTNEPackage = new JTNEPackage();
            jTNEPackage.AskId = askId.ToByteValue();
            jTNEPackage.MsgId = msgId;
            jTNEPackage.VIN = vin;
            return jTNEPackage;
        }
    }
}
