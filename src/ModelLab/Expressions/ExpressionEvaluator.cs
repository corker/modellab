using System;
using ModelLab.Graphs;

namespace ModelLab.Expressions
{
    public class ExpressionEvaluator : IEvaluateExpressions, IEvaluateGuards
    {
        public void Evaluate(IAmEdge edge)
        {
        }

        public void Evaluate(IAmNode node)
        {
        }

        bool IEvaluateGuards.Evaluate(IAmEdge edge)
        {
            return true;
        }
    }
}