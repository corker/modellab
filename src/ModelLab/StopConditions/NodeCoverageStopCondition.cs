using System;

namespace ModelLab.StopConditions
{
    public class NodeCoverageStopCondition : IEvaluateStopConditions
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