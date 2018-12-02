using ModelLab.DependencyInjection;

namespace ModelLab
{
    public static partial class Extensions
    {
        public static IBuildServiceProviders Register<TService>(this IBuildServiceProviders x)
        {
            var registration = new ServiceRegistryItemOfType<TService>();
            return x.Register(typeof(TService), registration);
        }

        public static IBuildServiceProviders Register<TService>(this IBuildServiceProviders x, TService instance)
        {
            var registration = new ServiceRegistryItemOfInstance(instance);
            return x.Register(typeof(TService), registration);
        }
    }
}