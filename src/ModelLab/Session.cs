using System;
using ModelLab.DependencyInjection;
using ModelLab.Sessions;

namespace ModelLab
{
    public static class Session
    {
        public static void Run(Action<IRegisterServices> configure)
        {
            var builder = new ServiceRegistryBuilder();
            builder.Use<SessionRunner>();
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