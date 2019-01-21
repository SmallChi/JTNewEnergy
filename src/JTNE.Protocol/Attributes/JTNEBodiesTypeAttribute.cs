using System;

namespace JTNE.Protocol.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class JTNEBodiesTypeAttribute : Attribute
    {
        public JTNEBodiesTypeAttribute(Type jT808BodiesType)
        {
            JT808BodiesType = jT808BodiesType;
        }
        public Type JT808BodiesType { get;}
    }
}
