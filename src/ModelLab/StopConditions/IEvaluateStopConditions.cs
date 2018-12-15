using ModelLab.Graphs;

namespace ModelLab.StopConditions
{
    public interface IEvaluateStopConditions
    {
        bool Evaluate(IAmNode node);
        bool Evaluate(IAmEdge edge);
    }
}