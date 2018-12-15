using ModelLab.Algorithms;
using ModelLab.DependencyInjection;
using ModelLab.Sessions;

namespace ModelLab
{
    public static partial class Extensions
    {
        public static IRegisterServices RandomAlgorithm(this IRegisterServices x)
        {
            var resolver = new ServiceResolverOfType<RandomAlgorithm>();
            return x.Register(typeof(ISelectEdges), resolver);
        }

        public static IRegisterServices QuickRandomAlgorithm(this IRegisterServices x)
        {
            var resolver = new ServiceResolverOfType<QuickRandomAlgorithm>();
            return x.Register(typeof(ISelectEdges), resolver);
        }

        public static IRegisterServices WeightedRandomAlgorithm(this IRegisterServices x)
        {
            var resolver = new ServiceResolverOfType<WeightedRandomAlgorithm>();
            return x.Register(typeof(ISelectEdges), resolver);
        }

        public static IRegisterServices AStarAlgorithm(this IRegisterServices x)
        {
            var resolver = new ServiceResolverOfType<AStarAlgorithm>();
            return x.Register(typeof(ISelectEdges), resolver);
        }
    }
}