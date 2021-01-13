using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Tools
{
    public class ThrowHelper
    {
        public static Func<T1, T2, TInstance> CreateInstance<T1, T2, TInstance>()
        {
            var argsTypes = new[] { typeof(T1), typeof(T2) };
            var names = new[] { "paramName", "message" };
            var constructor = typeof(TInstance).GetConstructor(BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, argsTypes, null);
            var args = argsTypes.Zip(names, (type, name) => Expression.Parameter(type, name)).ToArray();
            var newInstance = Expression.New(constructor, args);
            return Expression.Lambda<Func<T1, T2, TInstance>>(newInstance, args).Compile();
        }

        public static Func<T1, TInstance> CreateInstance<T1, TInstance>()
        {
            var argsTypes = new[] { typeof(T1) };
            var constructor = typeof(TInstance).GetConstructor(BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, argsTypes, null);
            var args = argsTypes.Select(Expression.Parameter).ToArray();
            var newInstance = Expression.New(constructor, args);
            return Expression.Lambda<Func<T1, TInstance>>(newInstance, args).Compile();
        }

        public static TInstance New<TInstance>(string message)
            where TInstance : Exception
        {
            Func<string, TInstance> product = CreateInstance<string, TInstance>();
            return product(message);
        }

        public static TInstance New<TInstance>(string paramName, string message)
            where TInstance : Exception
        {
            Func<string, string, TInstance> product = CreateInstance<string, string, TInstance>();
            return product(paramName, message);
        }

        public static TInstance New<TInstance>(string paramName, object param, string message)
            where TInstance : Exception
        {
            if (param == null)
            {
                return New<TInstance>(paramName, message);
            }
            string typename = param.GetType().Name;
            string concatMessage = $"{typename}: {message}";
            Func<string, string, TInstance> product = CreateInstance<string, string, TInstance>();
            return product(paramName, concatMessage);
        }
    }
}
