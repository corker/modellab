namespace ModelLab
{
    public interface IEvaluateStopConditions
    {
        bool Evaluate(IAmGraphNode node, IProvideSessionState state);
        bool Evaluate(IAmGraphEdge edge, IProvideSessionState state);
    }
}