using ModelLab.Expressions;
using ModelLab.Graphs;

namespace ModelLab.Elements
{
    public interface IProvideNodeElements
    {
        IAmElement FindByName(string name);
        IAmElement FindTargetFor(IAmEdge edge);
    }
}