using System.Collections.Generic;
using ModelLab.Graphs;

namespace ModelLab.Sessions
{
    public interface ISelectEdges
    {
        IAmEdge Select(IEnumerable<IAmEdge> edges);
    }
}