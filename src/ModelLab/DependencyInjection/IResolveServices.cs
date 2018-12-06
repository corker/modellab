namespace ModelLab.DependencyInjection
{
    public interface IResolveServices
    {
        object Resolve(IProvideServices services);
    }
}