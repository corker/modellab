using System.Reflection;
using ModelLab.DependencyInjection;
using ModelLab.Graphs;

namespace ModelLab
{
    public static partial class Extensions
    {
        public static IRegisterServices
            EmbeddedResource<T>(this IRegisterServices x, string value, Assembly assembly)
            where T : INavigateGraphs
        {
            var provider = new ServiceResolverOfEmbeddedResource<T>(value, assembly);
            return x.Register(typeof(INavigateGraphs), provider);
        }
    }
}