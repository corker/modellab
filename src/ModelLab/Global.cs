using System;
using ModelLab.DependencyInjection;

namespace ModelLab
{
    public static class Global
    {
        static Global()
        {
            CreateBuilder = () => new ServiceRegistryBuilder();
        }

        public static Func<IBuildServiceProviders> CreateBuilder { get; private set; }

        public static void Use(Func<IBuildServiceProviders> createBuilder)
        {
            CreateBuilder = createBuilder;
        }
    }
}