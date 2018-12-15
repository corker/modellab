using System.Linq;
using ModelLab.Sessions;

namespace ModelLab
{
    public class SessionRunner : IRunSessions
    {
        private readonly IExecuteSessionActions _actions;
        private readonly IProvideSessionElements _elements;
        private readonly IProvideSessionSettings _settings;

        public SessionRunner(
            IProvideSessionElements elements,
            IProvideSessionSettings settings,
            IExecuteSessionActions actions
        )
        {
            _elements = elements;
            _settings = settings;
            _actions = actions;
        }

        public void Run()
        {
            var element = _elements.FindByName(_settings.StartNodeName).FirstOrDefault();
            while (element != null)
            {
                _actions.ExecuteFor(element);
                element = element.Next();
            }
        }
    }
}