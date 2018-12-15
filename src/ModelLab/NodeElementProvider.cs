using System;

namespace ModelLab
{
    public class NodeElementProvider : IProvideNodeElements
    {
        private readonly ICreateNodeElements _elements;
        private readonly INavigateGraphs _graphs;

        public NodeElementProvider(ICreateNodeElements elements, INavigateGraphs graphs)
        {
            _elements = elements;
            _graphs = graphs;
        }

        public IIterateElements FindByName(string name)
        {
            var node = _graphs.FindNode(name);
            return _elements.TryCreateFrom(node);
        }

        public IIterateElements FindTargetFor(IAmGraphEdge edge)
        {
            var node = _graphs.FindTargetFor(edge);
            return _elements.TryCreateFrom(node);
        }
    }
}