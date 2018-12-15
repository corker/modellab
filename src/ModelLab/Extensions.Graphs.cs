using System;
using ModelLab.Graphs;

namespace ModelLab
{
    public static partial class Extensions
    {
        public static T Get<T>(this IProvideValues x) where T : class
        {
            var value = x.Find<T>();
            if (value != null) return value;
            var msg = $"Can't find a value of type {typeof(T).Name}";
            throw new ArgumentException(msg);
        }
    }
}