using ModelLab.Graphs;

namespace ModelLab.Graphml
{
    public interface IParseValues
    {
        IProvideValues Parse(string value);
    }
}