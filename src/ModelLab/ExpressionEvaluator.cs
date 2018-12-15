namespace ModelLab
{
    public class ExpressionEvaluator : IEvaluateExpressions, IEvaluateGuards
    {
        public IProvideSessionState Evaluate(IAmGraphNode node, IProvideSessionState state)
        {
            return new SessionStateProvider();
        }

        public IProvideSessionState Evaluate(IAmGraphEdge edge, IProvideSessionState state)
        {
            return new SessionStateProvider();
        }

        bool IEvaluateGuards.Evaluate(IAmGraphEdge edge, IProvideSessionState state)
        {
            return true;
        }
    }
}