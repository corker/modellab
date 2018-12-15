using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelLab.DependencyInjection
{
    public class ServiceRegistry : IProvideServices
    {
        private readonly ILookup<Type, IResolveServices> _lookup;
        private readonly IProvideServices _services;

        public ServiceRegistry(IEnumerable<Tuple<Type, IResolveServices>> tuples, IProvideServices services)
        {
            var instance = new ServiceResolverOfInstance(this);
            var tuple = new Tuple<Type, IResolveServices>(typeof(IProvideServices), instance);
            _lookup = tuples.Union(new[] {tuple}).ToLookup(x => x.Item1, x => x.Item2);
            _services = services;
        }

        public object Get(Type type)
        {
            var services = _lookup[type].SingleOrDefault();
            if (services != null) return services.Resolve(this);
            if (_services != null) return _services.Get(type);
            throw new ArgumentException($"Resolver of type [{type}] not found");
        }

        public IEnumerable<object> GetAll(Type type)
        {
            var services = _lookup[type].Select(x => x.Resolve(this)).ToArray();
            if (services.Any()) return services;
            if (_services != null) return _services.GetAll(type);
            throw new ArgumentException($"Resolver(s) of type [{type}] not found");
        }
    }
}