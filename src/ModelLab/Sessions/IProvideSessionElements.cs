using System.Collections.Generic;
using ModelLab.Elements;
using ModelLab.Graphs;

namespace ModelLab.Sessions
{
    public interface IProvideSessionElements
    {
        IEnumerable<IAmElement> FindByName(string name);
        IEnumerable<IAmElement> GetShared(IAmNode node);
    }
}