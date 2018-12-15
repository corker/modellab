namespace ModelLab
{
    public class NodeElementFactory : ICreateNodeElements
    {
        private readonly IEvaluateStopConditions _conditions;
        private readonly IProvideEdgeElements _elements;
        private readonly IEvaluateExpressions _expressions;

        public NodeElementFactory(
            IEvaluateStopConditions conditions,
            IProvideEdgeElements elements,
            IEvaluateExpressions expressions
        )
        {
            _conditions = conditions;
            _elements = elements;
            _expressions = expressions;
        }

        public IIterateElements TryCreateFrom(IAmGraphNode node)
        {
            return node == null
                ? null
                : new ModelNodeElement(node, _conditions, _elements, _expressions);
        }
    }
}