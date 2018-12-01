using System.Collections.Generic;
using System.Linq;

namespace ModelLab
{
    public static partial class Extensions
    {
        public static T Get<T>(this IProvideServices x)
        {
            return (T) x.Get(typeof(T));
        }

        public static IEnumerable<T> GetAll<T>(this IProvideServices x)
        {
            return x.GetAll(typeof(T)).OfType<T>();
        }
    }
}