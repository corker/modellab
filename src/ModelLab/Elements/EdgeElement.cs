using ModelLab.Expressions;
using ModelLab.Graphs;
using ModelLab.StopConditions;

namespace ModelLab.Elements
{
    public class EdgeElement : IAmElement, IProvideValues
    {
        private readonly IEvaluateStopConditions _conditions;
        private readonly IAmEdge _edge;
        private readonly IProvideNodeElements _elements;
        private readonly IEvaluateExpressions _expressions;

        public EdgeElement(
            IAmEdge edge,
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

        public IAmElement Next()
        {
            _expressions.Evaluate(_edge);
            return _conditions.Evaluate(_edge)
                ? null
                : _elements.FindTargetFor(_edge);
        }

        public T Find<T>() where T : class
        {
            return ((IProvideValues) _edge).Find<T>();
        }
    }
}