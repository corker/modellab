namespace ModelLab.DependencyInjection
{
    public class ServiceResolverOfInstance : IResolveServices
    {
        private readonly object _instance;

        public ServiceResolverOfInstance(object instance)
        {
            _instance = instance;
        }

        public object Resolve(IProvideServices services)
        {
            return _instance;
        }
    }
}