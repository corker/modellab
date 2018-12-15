using System;
using System.Linq;
using ModelLab.DependencyInjection;

namespace ModelLab
{
    public sealed class Session : IRunSessions
    {
        private readonly IProvideSessionElements _elements;
        private readonly IProvideSessionSettings _settings;
        private readonly IProvideSessionState _state;

        public Session(IProvideSessionElements elements, IProvideSessionSettings settings, IProvideSessionState state)
        {
            _elements = elements;
            _settings = settings;
            _state = state;
        }

        public void Run()
        {
            var element = _elements.FindByName(_settings.StartNodeName).FirstOrDefault();
            while (element != null) element = element.Next(_state);
        }

        public static void Run(Action<IRegisterServices> configure)
        {
            var builder = new ServiceRegistryBuilder();
            builder.Use<Session>();
            builder.Use<SessionElementProvider>();
            builder.Use<SessionStateProvider>();
            configure(builder);
            if (!builder.Contains<IProvideSessionSettings>()) builder.Use<SessionSettings>();
            var services = builder.Build();
            var sessions = services.Get<IRunSessions>();
            sessions.Run();
        }
    }
}