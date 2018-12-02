using ModelLab.DependencyInjection;

namespace ModelLab.Graphml
{
    public static class XunitExtensions
    {
        public static IBuildServiceProviders UseGraphml(this IBuildServiceProviders x)
        {
            x.Register<GraphmlModelReader>();
            return x;
        }
    }
}