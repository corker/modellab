using System;
using System.Linq;

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
            return Activator.CreateInstance(type, args);
        }
    }
}