using System;
using ModelLab.DependencyInjection;
using ModelLab.Expressions;
using ModelLab.StopConditions;

namespace ModelLab
{
    public static partial class Extensions
    {
        public static IRegisterServices EdgeCoverage(this IRegisterServices x, int value)
        {
            var resolver = new ServiceResolverOfType<EdgeCoverageStopCondition, int>(value);
            x.Register(typeof(IEvaluateStopConditions), resolver);
            return x;
        }

        public static IRegisterServices NodeCoverage(this IRegisterServices x, int value)
        {
            var resolver = new ServiceResolverOfType<NodeCoverageStopCondition, int>(value);
            x.Register(typeof(IEvaluateStopConditions), resolver);
            return x;
        }

        public static IRegisterServices RequirementCoverage(this IRegisterServices x, int value)
        {
            var resolver = new ServiceResolverOfType<RequirementCoverageStopCondition, int>(value);
            x.Register(typeof(IEvaluateStopConditions), resolver);
            return x;
        }

        public static IRegisterServices DependencyEdgeCoverage(this IRegisterServices x, int value)
        {
            var resolver = new ServiceResolverOfType<DependencyEdgeCoverageStopCondition, int>(value);
            x.Register(typeof(IEvaluateStopConditions), resolver);
            return x;
        }

        public static IRegisterServices ReachedNode(this IRegisterServices x, string value)
        {
            var resolver = new ServiceResolverOfType<ReachedNodeStopCondition, string>(value);
            x.Register(typeof(IEvaluateStopConditions), resolver);
            return x;
        }

        public static IRegisterServices ReachedEgde(this IRegisterServices x, string value)
        {
            var resolver = new ServiceResolverOfType<ReachedEdgeStopCondition, string>(value);
            x.Register(typeof(IEvaluateStopConditions), resolver);
            return x;
        }

        public static IRegisterServices TimeDuration(this IRegisterServices x, TimeSpan value)
        {
            var resolver = new ServiceResolverOfType<TimeDurationStopCondition, TimeSpan>(value);
            x.Register(typeof(IEvaluateStopConditions), resolver);
            return x;
        }

        public static IRegisterServices Length(this IRegisterServices x, int value)
        {
            var resolver = new ServiceResolverOfType<LengthStopCondition, int>(value);
            x.Register(typeof(IEvaluateStopConditions), resolver);
            return x;
        }

        public static IRegisterServices Never(this IRegisterServices x)
        {
            var resolver = new ServiceResolverOfType<NeverStopCondition>();
            x.Register(typeof(IEvaluateStopConditions), resolver);
            return x;
        }
    }
}