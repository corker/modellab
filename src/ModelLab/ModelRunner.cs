using System;
using System.Threading.Tasks;
using ModelLab.DependencyInjection;

namespace ModelLab
{
    public class ModelRunner : IRunModels
    {
        private readonly IProvideServices _services;

        public ModelRunner(IProvideServices services)
        {
            _services = services;
        }

        public Task RunAsync()
        {
            var models = _services.GetAll<IAmModel>();
            var impls = _services.GetAll<IImplementModels>();
            return Task.CompletedTask;
        }

        public static async Task RunAsync(Action<IBuildServiceProviders> configure)
        {
            var builder = new ServiceRegistryBuilder();
            builder.Register<IRunModels, ModelRunner>();
            configure(builder);
            var services = builder.Build();
            var runner = services.Get<IRunModels>();
            await runner.RunAsync();
        }
    }
}