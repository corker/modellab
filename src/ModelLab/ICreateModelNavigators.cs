using System.Collections.Generic;

namespace ModelLab
{
    public interface ICreateModelNavigators
    {
        INavigateModels Create(IEnumerable<IAmModel> models);
    }
}