namespace ModelLab
{
    public class EdgeElementFactory : ICreateEdgeElements
    {
        private readonly IEvaluateStopConditions _conditions;
        private readonly IProvideNodeElements _elements;
        private readonly IEvaluateExpressions _expressions;

        public EdgeElementFactory(
            IEvaluateStopConditions conditions,
            IEvaluateExpressions expressions,
            IProvideNodeElements elements
        )
        {
            _conditions = conditions;
            _expressions = expressions;
            _elements = elements;
        }

        public IIterateElements TryCreateFrom(IAmGraphEdge edge)
        {
            return edge == null
                ? null
                : new ModelEdgeElement(edge, _conditions, _elements, _expressions);
        }
    }
}