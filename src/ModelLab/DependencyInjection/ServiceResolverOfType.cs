using System;
using System.Linq;
using System.Reflection;

namespace ModelLab.DependencyInjection
{
    public class ServiceResolverOfType<T> : IResolveServices
    {
        public object Resolve(IProvideServices services)
        {
            var type = typeof(T);
            var constructorInfo = type.GetConstructors().Single();
            var parameters = constructorInfo.GetParameters();
            var args = parameters.Select(x => services.Get(x.ParameterType)).ToArray();
            return (T) Activator.CreateInstance(type, args);
        }
    }

    public class ServiceResolverOfType<T, T1> : IResolveServices
    {
        private readonly T1 _value;

        public ServiceResolverOfType(T1 value)
        {
            _value = value;
        }

        public object Resolve(IProvideServices services)
        {
            var type = typeof(T);
            var constructorInfo = type.GetConstructors().Single();
            var parameters = constructorInfo.GetParameters();
            var args = parameters.Select(x => GetArgument(services, x)).ToArray();
            return (T) Activator.CreateInstance(type, args);
        }

        private object GetArgument(IProvideServices services, ParameterInfo x)
        {
            return x.ParameterType == typeof(T1)
                ? _value
                : services.Get(x.ParameterType);
        }
    }
}