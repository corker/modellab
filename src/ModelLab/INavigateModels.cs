using System.Collections.Generic;

namespace ModelLab
{
    public interface INavigateModels
    {
        IAmGraphNode GetNode(string name);
        IEnumerable<IAmGraphEdge> GetEdges(IAmGraphNode node);
        IAmGraphNode GetNode(IAmGraphEdge edge);
    }
}