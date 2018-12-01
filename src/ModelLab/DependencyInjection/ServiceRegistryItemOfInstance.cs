namespace ModelLab.DependencyInjection
{
    public class ServiceRegistryItemOfInstance : ICreateServices
    {
        private readonly object _instance;

        public ServiceRegistryItemOfInstance(object instance)
        {
            _instance = instance;
        }

        public object Create(IProvideServices services)
        {
            return _instance;
        }
    }
}