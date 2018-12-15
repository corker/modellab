using System.Collections.Generic;
using System.Linq;
using ModelLab.DependencyInjection;
using ModelLab.Elements;
using ModelLab.Graphs;

namespace ModelLab.Sessions
{
    public class SessionElementProvider : IProvideSessionElements
    {
        private readonly IEnumerable<IProvideNodeElements> _elements;

        public SessionElementProvider(IProvideServices services)
        {
            _elements = services.GetAll<IProvideNodeElements>();
        }

        public IEnumerable<IAmElement> FindByName(string name)
        {
            return _elements.Select(x => x.FindByName(name)).Where(x => x != null);
        }

        public IEnumerable<IAmElement> GetShared(IAmNode node)
        {
            return new List<IAmElement>();
        }
    }
}