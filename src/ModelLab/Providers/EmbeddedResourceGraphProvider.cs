using System.Reflection;

namespace ModelLab
{
    public class EmbeddedResourceGraphProvider<T> : IProvideGraphs
    {
        private readonly Assembly _assembly;
        private readonly string _value;

        public EmbeddedResourceGraphProvider(string value, Assembly assembly)
        {
            _value = value;
            _assembly = assembly;
        }
    }
}