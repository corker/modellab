using ModelLab.DependencyInjection;

namespace ModelLab
{
    public static partial class Extensions
    {
        public static IRegisterServices Use<TService>(this IRegisterServices x)
        {
            var registration = new ServiceResolverOfType<TService>();
            return x.Register(typeof(TService), registration);
        }

        public static IRegisterServices Use<TService>(this IRegisterServices x, TService instance)
        {
            var registration = new ServiceResolverOfInstance(instance);
            return x.Register(typeof(TService), registration);
        }
    }
}