using System.Collections.Generic;
using System.Linq;
using ModelLab.DependencyInjection;

namespace ModelLab
{
    public class SessionElementProvider : IProvideSessionElements
    {
        private readonly IEnumerable<IProvideNodeElements> _elements;

        public SessionElementProvider(IProvideServices services)
        {
            _elements = services.GetAll<IProvideNodeElements>();
        }

        public IEnumerable<IIterateElements> FindByName(string name)
        {
            return _elements.Select(x => x.FindByName(name)).Where(x => x != null);
        }

        public IEnumerable<IIterateElements> GetShared(IAmGraphNode node)
        {
            return new List<IIterateElements>();
        }
    }
}