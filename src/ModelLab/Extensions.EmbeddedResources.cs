using System.Reflection;
using ModelLab.DependencyInjection;

namespace ModelLab
{
    public static partial class Extensions
    {
        public static IBuildServiceProviders UseEmbeddedResource<T>(this IBuildServiceProviders x, string value)
        {
            var assembly = Assembly.GetCallingAssembly();
            return x.UseEmbeddedResource<T>(value, assembly);
        }

        public static IBuildServiceProviders UseEmbeddedResource<T>(
            this IBuildServiceProviders x,
            string value,
            Assembly assembly
        )
        {
            var services = new ServiceRegistryItemOfEmbeddedResource<T>(value, assembly);
            return x.Register(typeof(T), services);
        }

        public static string AsEmbeddedResourceName(this string value, Assembly assembly)
        {
            return $"{assembly.GetName().Name}.{value.Replace("/", ".")}";
        }
    }
}