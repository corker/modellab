namespace ModelLab.Configuration
{
    public interface IConfigureGenerators
    {
        IConfigureImplementations Use(IProvideGenerators generators);
    }
}