using ModelLab.DependencyInjection;

namespace ModelLab
{
    public static partial class Extensions
    {
        public static IBuildServiceProviders UseModelImplementation<T>(this IBuildServiceProviders x)
        {
            return x
                .Register<T>()
                .Register<IImplementModels, ModelImplementation<T>>();
        }
    }
}