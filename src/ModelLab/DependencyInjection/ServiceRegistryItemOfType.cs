using System;
using System.Linq;

namespace ModelLab.DependencyInjection.ServiceRegistrations
{
    public class ServiceRegistryItemOfType<T> : ICreateServices
    {
        private object _instance;

        public object Create(IProvideServices services)
        {
            if (_instance == null)
            {
                var type = typeof(T);
                var constructorInfo = type.GetConstructors().Single();
                var parameters = constructorInfo.GetParameters();
                var args = parameters.Select(x => services.Get(x.ParameterType)).ToArray();
                _instance = Activator.CreateInstance(type, args);
            }

            return _instance;
        }
    }
}