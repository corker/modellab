using ModelLab.DependencyInjection;

namespace ModelLab
{
    public static partial class Extensions
    {
        public static IBuildServiceProviders Register<TService>(this IBuildServiceProviders x)
        {
            var registration = new ServiceResolverOfType<TService>();
            return x.Register(typeof(TService), registration);
        }

        public static IBuildServiceProviders Register<TService>(this IBuildServiceProviders x, TService instance)
        {
            var registration = new ServiceResolverOfInstance(instance);
            return x.Register(typeof(TService), registration);
        }
    }
}