using System;
using ModelLab.Elements;
using ModelLab.Expressions;

namespace ModelLab.DependencyInjection
{
    public class ServiceResolverOfModel : IResolveServices
    {
        private readonly Action<IRegisterServices> _action;

        public ServiceResolverOfModel(Action<IRegisterServices> action)
        {
            _action = action;
        }

        public object Resolve(IProvideServices services)
        {
            var builder = new ServiceRegistryBuilder(services);
            _action(builder);
            builder.Use<NodeElementProvider>();
            builder.Use<NodeElementFactory>();
            builder.Use<EdgeElementProvider>();
            builder.Use<EdgeElementFactory>();
            builder.Use<ExpressionEvaluator>();
            services = builder.Build();
            return services.Get<IProvideNodeElements>();
        }
    }
}