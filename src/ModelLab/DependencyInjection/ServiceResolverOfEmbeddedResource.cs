using System.Reflection;
using ModelLab.Infrastructure;

namespace ModelLab.DependencyInjection
{
    public class ServiceResolverOfEmbeddedResource<T> : IResolveServices
    {
        private readonly Assembly _assembly;
        private readonly string _value;

        public ServiceResolverOfEmbeddedResource(string value, Assembly assembly)
        {
            _value = value;
            _assembly = assembly;
        }

        public object Resolve(IProvideServices services)
        {
            var name = AsEmbeddedResourceName(_value, _assembly);
            var stream = _assembly.GetManifestResourceStream(name);
            var reader = services.Get<IReadStreams<T>>();
            return reader.ReadFrom(stream);
        }


        private static string AsEmbeddedResourceName(string value, Assembly assembly)
        {
            return $"{assembly.GetName().Name}.{value.Replace("/", ".")}";
        }
    }
}