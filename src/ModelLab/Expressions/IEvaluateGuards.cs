using ModelLab.Graphs;

namespace ModelLab.Expressions
{
    public interface IEvaluateGuards
    {
        bool Evaluate(IAmEdge edge);
    }
}