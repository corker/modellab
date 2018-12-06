using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelLab.DependencyInjection
{
    public class ServiceRegistry : IProvideServices
    {
        private readonly Dictionary<Type, object> _cache;
        private readonly ILookup<Type, IResolveServices> _lookup;

        public ServiceRegistry(IEnumerable<Tuple<Type, IResolveServices>> tuples)
        {
            var instance = new ServiceResolverOfInstance(this);
            var tuple = new Tuple<Type, IResolveServices>(typeof(IProvideServices), instance);
            tuples = tuples.Union(new[] {tuple});
            _lookup = tuples.ToLookup(x => x.Item1, x => x.Item2);
            _cache = new Dictionary<Type, object>();
        }

        public object Get(Type type)
        {
            if (_cache.TryGetValue(type, out var value)) return value;
            var services = _lookup[type].Single();
            value = services.Resolve(this);
            _cache.Add(type, value);
            return value;
        }

        public IEnumerable<object> GetAll(Type type)
        {
            if (_cache.TryGetValue(type, out var value)) return (IEnumerable<object>) value;
            var services = _lookup[type];
            value = services.Select(x => x.Resolve(this)).ToArray();
            _cache.Add(type, value);
            return (IEnumerable<object>) value;
        }
    }
}