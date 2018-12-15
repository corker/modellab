namespace ModelLab
{
    public class ModelEdgeElement : IIterateElements
    {
        private readonly IEvaluateStopConditions _conditions;
        private readonly IAmGraphEdge _edge;
        private readonly IProvideNodeElements _elements;
        private readonly IEvaluateExpressions _expressions;

        public ModelEdgeElement(
            IAmGraphEdge edge,
            IEvaluateStopConditions conditions,
            IProvideNodeElements elements,
            IEvaluateExpressions expressions
        )
        {
            _edge = edge;
            _conditions = conditions;
            _elements = elements;
            _expressions = expressions;
        }

        public IIterateElements Next(IProvideSessionState state)
        {
            state = _expressions.Evaluate(_edge, state);
            return _conditions.Evaluate(_edge, state)
                ? null
                : _elements.FindTargetFor(_edge);
        }
    }
}