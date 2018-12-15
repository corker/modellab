using ModelLab.Expressions;
using ModelLab.Graphs;
using ModelLab.StopConditions;

namespace ModelLab.Elements
{
    public class NodeElement : IAmElement, IProvideValues
    {
        private readonly IEvaluateStopConditions _conditions;
        private readonly IProvideEdgeElements _edges;
        private readonly IEvaluateExpressions _expressions;
        private readonly IAmNode _node;

        public NodeElement(
            IAmNode node,
            IEvaluateStopConditions conditions,
            IProvideEdgeElements edges,
            IEvaluateExpressions expressions)
        {
            _node = node;
            _conditions = conditions;
            _edges = edges;
            _expressions = expressions;
        }

        public IAmElement Next()
        {
            _expressions.Evaluate(_node);
            return _conditions.Evaluate(_node)
                ? null
                : _edges.Find(_node);
        }

        public T Find<T>() where T : class
        {
            return ((IProvideValues) _node).Find<T>();
        }
    }
}