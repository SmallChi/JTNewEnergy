using JTNE.Protocol.Attributes;
using JTNE.Protocol.Enums;
using JTNE.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Internal
{
    internal static class JTNEMsgIdFactory
    {
        private static readonly Dictionary<byte, Type> map;

        static JTNEMsgIdFactory()
        {
            map = new Dictionary<byte, Type>();
            InitMap();
        }

        internal static Type GetBodiesImplTypeByMsgId(byte msgId) =>map.TryGetValue(msgId, out Type type) ? type : null;

        private static void InitMap()
        {
           foreach(var item  in Enum.GetNames(typeof(JTNEMsgId)))
           {
                JTNEMsgId msgId = item.ToEnum<JTNEMsgId>();
                JTNEBodiesTypeAttribute jT808BodiesTypeAttribute = msgId.GetAttribute<JTNEBodiesTypeAttribute>();
                map.Add((byte)msgId, jT808BodiesTypeAttribute?.JT808BodiesType);
           }
        }

        internal static void SetMap<TJTNEBodies>(byte msgId)
            where TJTNEBodies : JTNEBodies
        {
            if(!map.ContainsKey(msgId))
                map.Add(msgId, typeof(TJTNEBodies));
        }

        internal static void ReplaceMap<TJTNEBodies>(byte msgId)
            where TJTNEBodies : JTNEBodies
        {
            if (!map.ContainsKey(msgId))
                map.Add(msgId, typeof(TJTNEBodies));
            else
                map[msgId] = typeof(TJTNEBodies);
        }
    }
}
