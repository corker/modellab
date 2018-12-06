using ModelLab.Configuration;

namespace ModelLab
{
    public interface IConfigureModels
    {
        IConfigureGenerators Use(IProvideGraphs graphs);
    }
}