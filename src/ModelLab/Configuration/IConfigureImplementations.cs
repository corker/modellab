using ModelLab.Providers;

namespace ModelLab.Configuration
{
    public interface IConfigureImplementations
    {
        IConfigureImplementations Use(IProvideImplementations implementations);
    }
}