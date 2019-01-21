using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class JTNEMsgIdDescriptionAttribute : Attribute
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public JTNEMsgIdDescriptionAttribute(string code,string name)
        {
            Code = code;
            Name = name;
        }
    }
}
