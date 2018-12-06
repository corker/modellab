using System;

namespace ModelLab.StopConditions
{
    public interface IVerifyStopConditions
    {
        bool EdgeCoverage(int value);
        bool NodeCoverage(int value);
        bool RequirementCoverage(int value);
        bool DependencyEdgeCoverage(int value);
        bool ReachedNode(string value);
        bool ReachedEgde(string value);
        bool TimeDuration(TimeSpan value);
        bool Length(int value);
        bool Never();
    }
}