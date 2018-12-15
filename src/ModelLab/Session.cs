using System;
using System.Linq;
using ModelLab.DependencyInjection;
using ModelLab.Expressions;
using ModelLab.Sessions;

namespace ModelLab
{
    public sealed class Session : IRunSessions
    {
        private readonly IExecuteSessionActions _actions;
        private readonly IProvideSessionElements _elements;
        private readonly IProvideSessionSettings _settings;

        public Session(
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

        public static void Run(Action<IRegisterServices> configure)
        {
            var builder = new ServiceRegistryBuilder();
            builder.Use<Session>();
            builder.Use<SessionElementProvider>();
            builder.Use<SessionActionExecutor>();
            configure(builder);
            if (!builder.Contains<IProvideSessionSettings>()) builder.Use<SessionSettings>();
            var services = builder.Build();
            var sessions = services.Get<IRunSessions>();
            sessions.Run();
        }
    }
}