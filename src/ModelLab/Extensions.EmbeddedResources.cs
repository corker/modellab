using System;
using System.Reflection;
using ModelLab.DependencyInjection;

namespace ModelLab
{
    public static partial class Extensions
    {
        public static IBuildServiceProviders UseEmbeddedResource<T>(this IBuildServiceProviders x, string value)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return x.UseEmbeddedResource<T>(value, assembly);
        }

        public static IBuildServiceProviders UseEmbeddedResource<T>(
            this IBuildServiceProviders x,
            string value,
            Assembly assembly
        )
        {
            var name = value.AsEmbeddedResourceName(assembly);
            var stream = assembly.GetManifestResourceStream(name);
            var instance = (T) Activator.CreateInstance(typeof(T), stream);
            return x.Register(instance);
        }

        public static string AsEmbeddedResourceName(this string value, Assembly assembly)
        {
            return $"{assembly.GetName().Name}.{value.Replace("/", ".")}";
        }
    }
}