using System.Collections.Generic;
using ModelLab.Actions;
using ModelLab.DependencyInjection;
using ModelLab.Elements;

namespace ModelLab.Sessions
{
    public class SessionActionExecutor : IExecuteSessionActions
    {
        private readonly IEnumerable<IExecuteActions> _actions;

        public SessionActionExecutor(IProvideServices services)
        {
            _actions = services.GetAll<IExecuteActions>();
        }

        public void ExecuteFor(IAmElement element)
        {
            foreach (var actions in _actions) actions.ExecuteFor(element);
        }
    }
}