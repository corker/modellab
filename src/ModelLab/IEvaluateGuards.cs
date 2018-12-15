namespace ModelLab
{
    public interface IEvaluateGuards
    {
        bool Evaluate(IAmGraphEdge edge, IProvideSessionState state);
    }
}