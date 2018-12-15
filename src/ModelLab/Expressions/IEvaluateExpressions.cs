using ModelLab.Graphs;

namespace ModelLab.Expressions
{
    public interface IEvaluateExpressions
    {
        void Evaluate(IAmEdge edge);
        void Evaluate(IAmNode node);
    }
}