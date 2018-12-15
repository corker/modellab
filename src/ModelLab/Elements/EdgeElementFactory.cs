using ModelLab.Expressions;
using ModelLab.Graphs;
using ModelLab.StopConditions;

namespace ModelLab.Elements
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

        public IAmElement TryCreateFrom(IAmEdge edge)
        {
            return edge == null
                ? null
                : new EdgeElement(edge, _conditions, _elements, _expressions);
        }
    }
}