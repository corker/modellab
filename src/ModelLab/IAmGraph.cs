using System.Collections.Generic;

namespace ModelLab
{
    public interface IAmGraph
    {
        IEnumerable<IAmGraphNode> Nodes { get; }
        IEnumerable<IAmGraphEdge> Edges { get; }
    }
}