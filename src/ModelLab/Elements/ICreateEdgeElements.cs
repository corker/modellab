using ModelLab.Graphs;

namespace ModelLab.Elements
{
    public interface ICreateEdgeElements
    {
        IAmElement TryCreateFrom(IAmEdge edge);
    }
}