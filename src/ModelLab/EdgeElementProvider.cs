using System;
using System.Linq;

namespace ModelLab
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

        public IIterateElements Find(IAmGraphNode node, IProvideSessionState state)
        {
            var edges = _graphs.GetEdges(node).Where(x => _guards.Evaluate(x, state));
            var shared = _sessionElements.GetShared(node).Select(x => new ElementWrapper(x));
            var edge = _edges.Select(edges.Union(shared));
            if (edge is ElementWrapper wrapper) return wrapper.Element;
            return _elements.TryCreateFrom(edge);
        }

        private class ElementWrapper : IAmGraphEdge
        {
            public ElementWrapper(IIterateElements elements)
            {
                Element = elements;
            }

            public IIterateElements Element { get; }
            public string Label => throw new InvalidOperationException();
        }
    }
}