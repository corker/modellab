using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelLab.DependencyInjection
{
    public partial class ServiceRegistryBuilder : IRegisterServices
    {
        private readonly List<Tuple<Type, IResolveServices>> _collections;
        private readonly IProvideServices _services;
        private readonly HashSet<Type> _types;

        public ServiceRegistryBuilder(IProvideServices services = null)
        {
            _collections = new List<Tuple<Type, IResolveServices>>();
            _services = services;
            _types = new HashSet<Type>();
        }

        public IRegisterServices Register(Type type, IResolveServices services)
        {
            //{
            //    var cacheDecorator = new ServiceResolverCacheDecorator(services);
            //    var tuple = new Tuple<Type, IResolveServices>(type, cacheDecorator);
            //    _collections.Add(tuple);
            //    _types.Add(tuple.Item1);
            //}
            var interfaces = type.GetInterfaces().ToList();
            if (type.IsInterface) interfaces.Add(type);
            foreach (var @interface in interfaces)
            {
                var proxyDecorator = new ServiceResolverProxyDecorator(services, @interface);
                var tuple = new Tuple<Type, IResolveServices>(@interface, proxyDecorator);
                _collections.Add(tuple);
                _types.Add(tuple.Item1);
            }

            return this;
        }

        public IProvideServices Build()
        {
            return new ServiceRegistry(_collections, _services);
        }

        public bool Contains<T>()
        {
            return _types.Contains(typeof(T));
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

        private class ServiceResolverProxyDecorator : IResolveServices
        {
            private readonly IResolveServices _services;
            private readonly Type _type;
            private ServiceProxy _proxy;

            public ServiceResolverProxyDecorator(IResolveServices services, Type type)
            {
                _services = services;
                _type = type;
            }

            public object Resolve(IProvideServices services)
            {
                if (_proxy != null) return _proxy;
                _proxy = ServiceProxy.Create(_type);
                var service = _services.Resolve(services);
                _proxy.Set(service);
                return _proxy;
            }
        }
    }
}