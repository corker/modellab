using System;
using System.Linq;

namespace ModelLab.DependencyInjection.ServiceRegistrations
{
    public class ServiceRegistryItemOfType<T> : ICreateServices
    {
        public object Create(IProvideServices services)
        {
            var type = typeof(T);
            var constructorInfo = type.GetConstructors().Single();
            var parameters = constructorInfo.GetParameters();
            var args = parameters.Select(x => services.Get(x.ParameterType)).ToArray();
            return Activator.CreateInstance(type, args);
        }
    }
}