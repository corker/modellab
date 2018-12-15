using System.Collections.Generic;

namespace ModelLab
{
    public interface ISelectEdges
    {
        IAmGraphEdge Select(IEnumerable<IAmGraphEdge> edges);
    }
}