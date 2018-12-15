namespace ModelLab
{
    public interface IEvaluateExpressions
    {
        IProvideSessionState Evaluate(IAmGraphNode node, IProvideSessionState state);
        IProvideSessionState Evaluate(IAmGraphEdge edge, IProvideSessionState state);
    }
}