using System.Reflection;

namespace ModelLab.DependencyInjection
{
    public class ServiceResolverOfEmbeddedResource<T>: IResolveServices
    {
        private readonly Assembly _assembly;
        private string _name;

        public ServiceResolverOfEmbeddedResource(string value, Assembly assembly)
        {
            _assembly = assembly;
            _name = value.AsEmbeddedResourceName(assembly);
        }

        public object Resolve(IProvideServices services)
        {
            var type = typeof(T);
            var stream = _assembly.GetManifestResourceStream(_name);
            var reader = services.Get<IReadStreams<T>>();
            return reader.ReadFrom(stream);
        }
    }
}