using System;

namespace ModelLab.StopConditions
{
    public class EdgeCoverageStopCondition : IEvaluateStopConditions
    {
        public bool Evaluate(IAmGraphNode node, IProvideSessionState state)
        {
            throw new NotImplementedException();
        }

        public bool Evaluate(IAmGraphEdge edge, IProvideSessionState state)
        {
            throw new NotImplementedException();
        }
    }
}