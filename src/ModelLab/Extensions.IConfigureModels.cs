using System;
using System.Reflection;
using ModelLab.Configuration;
using ModelLab.Generators;
using ModelLab.StopConditions;

namespace ModelLab
{
    public static partial class Extensions
    {
        public static IConfigureGenerators
            EmbeddedResource<T>(this IConfigureModels x, string value)
            where T : IAmGraph
        {
            return x.EmbeddedResource<T>(value, Assembly.GetCallingAssembly());
        }

        public static IConfigureGenerators
            EmbeddedResource<T>(this IConfigureModels x, string value, Assembly assembly)
            where T : IAmGraph
        {
            var provider = new EmbeddedResourceGraphProvider<T>(value, assembly);
            return x.Use(provider);
        }

        public static IConfigureImplementations
            Random(this IConfigureGenerators x, Func<IVerifyStopConditions, bool> condition)
        {
            var provider = new GeneratorProvider<RandomGenerator>(condition);
            return x.Use(provider);
        }

        public static IConfigureImplementations
            WeightedRandom(this IConfigureGenerators x, Func<IVerifyStopConditions, bool> condition)
        {
            var provider = new GeneratorProvider<WeightedRandomGenerator>(condition);
            return x.Use(provider);
        }

        public static IConfigureImplementations
            QuickRandom(this IConfigureGenerators x, Func<IVerifyStopConditions, bool> condition)
        {
            var provider = new GeneratorProvider<QuickRandomGenerator>(condition);
            return x.Use(provider);
        }

        public static IConfigureImplementations
            AStar(this IConfigureGenerators x, Func<IVerifyStopConditions, bool> condition)
        {
            var provider = new GeneratorProvider<AStarGenerator>(condition);
            return x.Use(provider);
        }

        public static IConfigureImplementations
            Implementation<T>(this IConfigureImplementations x)
        {
            var provider = new ImplementationProvider<T>();
            return x.Use(provider);
        }
    }
}