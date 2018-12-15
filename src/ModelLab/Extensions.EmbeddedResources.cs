using System.Reflection;
using ModelLab.DependencyInjection;

namespace ModelLab
{
    public static partial class Extensions
    {
        public static IRegisterServices UseEmbeddedResource<T>(
            this IRegisterServices x,
            string value,
            Assembly assembly
        )
        {
            var services = new ServiceResolverOfEmbeddedResource<T>(value, assembly);
            return x.Register(typeof(T), services);
        }
    }
}