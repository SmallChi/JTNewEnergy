using System;
using System.Reflection;
using JTNE.Protocol.Formatters;
using JTNE.Protocol.Enums;
using JTNE.Protocol.Attributes;
using JTNE.Protocol.Exceptions;

namespace JTNE.Protocol.Extensions
{
    public  static class JTNEFormatterExtensions
    {
        public static IJTNEFormatter<T> GetFormatter<T>()
        {
            IJTNEFormatter<T> formatter;
            var attr = typeof(T).GetTypeInfo().GetCustomAttribute<JTNEFormatterAttribute>();
            if (attr == null)
            {
                return default;
            }
            if (attr.Arguments == null)
            {
                formatter = (IJTNEFormatter<T>)Activator.CreateInstance(attr.FormatterType);
            }
            else
            {
                formatter = (IJTNEFormatter<T>)Activator.CreateInstance(attr.FormatterType, attr.Arguments);
            }
            return formatter;
        }

        public static object GetFormatter(Type formatterType)
        {
            object formatter;
            var attr = formatterType.GetTypeInfo().GetCustomAttribute<JTNEFormatterAttribute>();
            if (attr == null)
            {
                throw new JTNEException(JTNEErrorCode.GetFormatterAttributeError, formatterType.FullName);
            }
            if (attr.Arguments == null)
            {
                formatter = Activator.CreateInstance(attr.FormatterType);
            }
            else
            {
                formatter = Activator.CreateInstance(attr.FormatterType, attr.Arguments);
            }
            return formatter;
        }
    }
}
