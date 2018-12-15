using ModelLab.DependencyInjection;

namespace ModelLab
{
    public static partial class Extensions
    {
        public static IRegisterServices UseModelImplementation<T>(this IRegisterServices x)
        {
            return x
                .Use<T>()
                .Use<ModelImplementation<T>>();
        }
    }
}