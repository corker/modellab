using System;
using ModelLab.DependencyInjection;

namespace ModelLab
{
    public static partial class Extensions
    {
        public static IBuildServiceProviders UseModel(this IBuildServiceProviders x, Action<IConfigureModels> action)
        {
            var builder = new ModelBuilder(action);
            return x.Register<IBuildModels>(builder);
        }
    }
}