using System.Collections.Generic;

namespace ModelLab
{
    public interface INavigateGraphs
    {
        IAmGraphNode FindNode(string name);
        IEnumerable<IAmGraphEdge> GetEdges(IAmGraphNode node);
        IAmGraphNode FindTargetFor(IAmGraphEdge edge);
    }
}