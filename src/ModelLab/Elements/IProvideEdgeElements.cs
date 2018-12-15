using ModelLab.Graphs;

namespace ModelLab.Elements
{
    public interface IProvideEdgeElements
    {
        IAmElement Find(IAmNode node);
    }
}