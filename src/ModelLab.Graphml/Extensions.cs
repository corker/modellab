using System.Reflection;
using ModelLab.DependencyInjection;

namespace ModelLab.Graphml
{
    public static class Extensions
    {
        public static IRegisterServices
            GraphmlEmbeddedResource(this IRegisterServices x, string value)
        {
            return x.GraphmlEmbeddedResource(value, Assembly.GetCallingAssembly());
        }

        public static IRegisterServices
            GraphmlEmbeddedResource(this IRegisterServices x, string value, Assembly assembly)
        {
            return x.EmbeddedResource<GraphmlNavigator>(value, assembly);
        }
    }
}