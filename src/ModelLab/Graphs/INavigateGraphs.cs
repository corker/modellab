using System.Collections.Generic;

namespace ModelLab.Graphs
{
    public interface INavigateGraphs
    {
        IAmNode FindNode(string name);
        IEnumerable<IAmEdge> GetEdges(IAmNode node);
        IAmNode FindTargetFor(IAmEdge edge);
    }
}