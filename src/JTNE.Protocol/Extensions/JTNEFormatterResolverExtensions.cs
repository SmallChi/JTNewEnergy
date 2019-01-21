using JTNE.Protocol.Formatters;
using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace JTNE.Protocol.Extensions
{
    /// <summary>
    /// 
    /// ref http://adamsitnik.com/Span/#span-must-not-be-a-generic-type-argument
    /// ref http://adamsitnik.com/Span/
    /// ref:MessagePack.Formatters.DynamicObjectTypeFallbackFormatter
    /// </summary>
    public static class JTNEFormatterResolverExtensions
    {
        delegate int JTNESerializeMethod(object dynamicFormatter, ref byte[] bytes, int offset, object value);

        delegate dynamic JTNEDeserializeMethod(object dynamicFormatter, ReadOnlySpan<byte> bytes,  out int readSize);

        static readonly ConcurrentDictionary<Type, (object Value, JTNESerializeMethod SerializeMethod)> jTNESerializers = new ConcurrentDictionary<Type, (object Value, JTNESerializeMethod SerializeMethod)>();

        static readonly ConcurrentDictionary<Type, (object Value, JTNEDeserializeMethod DeserializeMethod)> jTNEDeserializes = new ConcurrentDictionary<Type, (object Value, JTNEDeserializeMethod DeserializeMethod)>();

        public static int JTNEDynamicSerialize(object objFormatter, ref byte[] bytes, int offset, dynamic value)
        {
            Type type = value.GetType();
            var ti = type.GetTypeInfo();
            (object Value, JTNESerializeMethod SerializeMethod) formatterAndDelegate;
            if (!jTNESerializers.TryGetValue(type, out formatterAndDelegate))
            {
                var t = type;
                {
                    var formatterType = typeof(IJTNEFormatter<>).MakeGenericType(t);
                    var param0 = Expression.Parameter(typeof(object), "formatter");
                    var param1 = Expression.Parameter(typeof(byte[]).MakeByRefType(), "bytes");
                    var param2 = Expression.Parameter(typeof(int), "offset");
                    var param3 = Expression.Parameter(typeof(object), "value");
                    var serializeMethodInfo = formatterType.GetRuntimeMethod("Serialize", new[] { typeof(byte[]).MakeByRefType(), typeof(int), t});
                    var body = Expression.Call(
                        Expression.Convert(param0, formatterType),
                        serializeMethodInfo,
                        param1,
                        param2,
                        ti.IsValueType ? Expression.Unbox(param3, t) : Expression.Convert(param3, t));
                    var lambda = Expression.Lambda<JTNESerializeMethod>(body, param0, param1, param2, param3).Compile();
                    formatterAndDelegate = (objFormatter, lambda);
                }
                jTNESerializers.TryAdd(t, formatterAndDelegate);
            }
            return formatterAndDelegate.SerializeMethod(formatterAndDelegate.Value,ref bytes, offset, value);
        }

        public static dynamic JTNEDynamicDeserialize(object objFormatter,ReadOnlySpan<byte> bytes, out int readSize)
        {
            var type = objFormatter.GetType();
            (object Value, JTNEDeserializeMethod DeserializeMethod) formatterAndDelegate;
            if (!jTNEDeserializes.TryGetValue(type, out formatterAndDelegate))
            {
                var t = type;
                {
                    var formatterType = typeof(IJTNEFormatter<>).MakeGenericType(t);
                    ParameterExpression param0 = Expression.Parameter(typeof(object), "formatter");
                    ParameterExpression param1 = Expression.Parameter(typeof(ReadOnlySpan<byte>), "bytes");
                    ParameterExpression param2 = Expression.Parameter(typeof(int).MakeByRefType(), "readSize");
                    var deserializeMethodInfo = type.GetRuntimeMethod("Deserialize", new[] { typeof(ReadOnlySpan<byte>), typeof(int).MakeByRefType() });
                    var body = Expression.Call(
                        Expression.Convert(param0, type),
                        deserializeMethodInfo,
                        param1,
                        param2
                        );
                    var lambda = Expression.Lambda<JTNEDeserializeMethod>(body, param0, param1, param2).Compile();
                    formatterAndDelegate = (objFormatter, lambda);
                }
                jTNEDeserializes.TryAdd(t, formatterAndDelegate);
            }
            return formatterAndDelegate.DeserializeMethod(formatterAndDelegate.Value, bytes,  out readSize);
        }
    }
}
