using System.Reflection;

namespace ModelLab.DependencyInjection
{
    public class ServiceRegistryItemOfEmbeddedResource<T>: ICreateServices
    {
        private readonly Assembly _assembly;
        private string _name;
        private object _instance;

        public ServiceRegistryItemOfEmbeddedResource(string value, Assembly assembly)
        {
            _assembly = assembly;
            _name = value.AsEmbeddedResourceName(assembly);
        }

        public object Create(IProvideServices services)
        {
            if (_instance == null)
            {
                var type = typeof(T);
                var stream = _assembly.GetManifestResourceStream(_name);
                var reader = services.Get<IReadStreams<T>>();
                _instance = reader.ReadFrom(stream);
            }

            return _instance;
        }
    }
}