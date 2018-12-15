namespace ModelLab
{
    public class ModelNodeElement : IIterateElements
    {
        private readonly IEvaluateStopConditions _conditions;
        private readonly IProvideEdgeElements _edges;
        private readonly IEvaluateExpressions _expressions;
        private readonly IAmGraphNode _node;

        public ModelNodeElement(
            IAmGraphNode node,
            IEvaluateStopConditions conditions,
            IProvideEdgeElements edges,
            IEvaluateExpressions expressions
        )
        {
            _node = node;
            _conditions = conditions;
            _edges = edges;
            _expressions = expressions;
        }

        public IIterateElements Next(IProvideSessionState state)
        {
            state = _expressions.Evaluate(_node, state);
            return _conditions.Evaluate(_node, state)
                ? null
                : _edges.Find(_node, state);
        }
    }
}