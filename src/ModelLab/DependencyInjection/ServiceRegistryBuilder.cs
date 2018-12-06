using System;
using System.Collections.Generic;

namespace ModelLab.DependencyInjection
{
    public class ServiceRegistryBuilder : IBuildServiceProviders
    {
        private readonly List<Tuple<Type, IResolveServices>> _collections;

        public ServiceRegistryBuilder()
        {
            _collections = new List<Tuple<Type, IResolveServices>>();
        }

        public IProvideServices Build()
        {
            return new ServiceRegistry(_collections);
        }

        public IBuildServiceProviders Register(Type type, IResolveServices services)
        {
            services = new ServiceResolverCacheDecorator(services);
            {
                var tuple = new Tuple<Type, IResolveServices>(type, services);
                _collections.Add(tuple);
            }
            var interfaces = type.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                var tuple = new Tuple<Type, IResolveServices>(@interface, services);
                _collections.Add(tuple);
            }

            return this;
        }

        private class ServiceResolverCacheDecorator : IResolveServices
        {
            private readonly IResolveServices _services;
            private object _cache;

            public ServiceResolverCacheDecorator(IResolveServices services)
            {
                _services = services;
            }

            public object Resolve(IProvideServices services)
            {
                if (_cache != null) return _cache;
                _cache = _services.Resolve(services);
                return _cache;
            }
        }
    }
}