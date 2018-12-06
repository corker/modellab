using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelLab
{
    public class ScenarioNavigator : INavigateModels
    {
        private readonly List<IAmModel> _models;

        public ScenarioNavigator()
        {
            _models = new List<IAmModel>();
        }

        public IAmGraphNode GetNode(string name)
        {
            return _models
                .Select(model => model.FindNode(name))
                .FirstOrDefault(node => node != null);
        }

        public IEnumerable<IAmGraphEdge> GetEdges(IAmGraphNode node)
        {
            throw new NotImplementedException();
        }

        public IAmGraphNode GetNode(IAmGraphEdge edge)
        {
            throw new NotImplementedException();
        }

        public void Add(IEnumerable<IAmModel> models)
        {
            _models.AddRange(models);
        }
    }
}