namespace ModelLab.DependencyInjection
{
    public interface ICreateServices
    {
        object Create(IProvideServices services);
    }
}