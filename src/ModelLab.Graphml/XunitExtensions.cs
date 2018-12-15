using ModelLab.DependencyInjection;

namespace ModelLab.Graphml
{
    public static class XunitExtensions
    {
        public static IRegisterServices UseGraphml(this IRegisterServices x)
        {
            x.Use<GraphmlModelReader>();
            return x;
        }
    }
}