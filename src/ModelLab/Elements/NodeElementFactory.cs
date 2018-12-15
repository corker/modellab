using ModelLab.Expressions;
using ModelLab.Graphs;
using ModelLab.Sessions;
using ModelLab.StopConditions;

namespace ModelLab.Elements
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

        public IAmElement TryCreateFrom(IAmNode node)
        {
            return node == null
                ? null
                : new NodeElement(node, _conditions, _elements, _expressions);
        }
    }
}