using System.Collections.Generic;

namespace ModelLab
{
    public interface IProvideSessionElements
    {
        IEnumerable<IIterateElements> FindByName(string name);
        IEnumerable<IIterateElements> GetShared(IAmGraphNode node);
    }
}