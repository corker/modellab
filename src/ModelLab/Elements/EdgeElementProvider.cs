using System.Linq;
using ModelLab.Expressions;
using ModelLab.Graphs;
using ModelLab.Sessions;

namespace ModelLab.Elements
{
    public class EdgeElementProvider : IProvideEdgeElements
    {
        private readonly ISelectEdges _edges;
        private readonly ICreateEdgeElements _elements;
        private readonly INavigateGraphs _graphs;
        private readonly IEvaluateGuards _guards;
        private readonly IProvideSessionElements _sessionElements;

        public EdgeElementProvider(
            INavigateGraphs graphs,
            IEvaluateGuards guards,
            ISelectEdges edges,
            IProvideSessionElements sessionElements,
            ICreateEdgeElements elements
        )
        {
            _graphs = graphs;
            _guards = guards;
            _edges = edges;
            _sessionElements = sessionElements;
            _elements = elements;
        }

        public IAmElement Find(IAmNode node)
        {
            var edges = _graphs.GetEdges(node).Where(x => _guards.Evaluate(x));
            var shared = _sessionElements.GetShared(node).Select(x => new ElementWrapper(x));
            var edge = _edges.Select(edges.Union(shared));
            if (edge is ElementWrapper wrapper) return wrapper.Element;
            return _elements.TryCreateFrom(edge);
        }

        private class ElementWrapper : IAmEdge
        {
            public ElementWrapper(IAmElement element)
            {
                Element = element;
            }

            public IAmElement Element { get; }
        }
    }
}