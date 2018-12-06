using System.Collections.Generic;

namespace ModelLab
{
    public class ModelNavigatorFactory : ICreateModelNavigators
    {
        public INavigateModels Create(IEnumerable<IAmModel> models)
        {
            var navigator = new ScenarioNavigator();
            navigator.Add(models);
            return navigator;
        }
    }
}