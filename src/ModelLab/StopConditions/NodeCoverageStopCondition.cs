using System;
using ModelLab.Expressions;
using ModelLab.Graphs;
using ModelLab.Sessions;

namespace ModelLab.StopConditions
{
    public class NodeCoverageStopCondition : IEvaluateStopConditions
    {
        public bool Evaluate(IAmNode node)
        {
            throw new NotImplementedException();
        }

        public bool Evaluate(IAmEdge edge)
        {
            throw new NotImplementedException();
        }
    }
}