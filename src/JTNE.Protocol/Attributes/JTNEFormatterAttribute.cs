using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public  sealed  class JTNEFormatterAttribute:Attribute
    {
        public Type FormatterType { get; private set; }

        public object[] Arguments { get; private set; }

        public JTNEFormatterAttribute(Type formatterType)
        {
            this.FormatterType = formatterType;
        }

        public JTNEFormatterAttribute(Type formatterType, params object[] arguments)
        {
            this.FormatterType = formatterType;
            this.Arguments = arguments;
        }
    }
}
