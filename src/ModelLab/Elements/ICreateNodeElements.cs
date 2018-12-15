using ModelLab.Expressions;
using ModelLab.Graphs;

namespace ModelLab.Elements
{
    public interface ICreateNodeElements
    {
        IAmElement TryCreateFrom(IAmNode node);
    }
}