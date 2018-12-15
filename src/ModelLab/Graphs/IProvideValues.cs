namespace ModelLab.Graphs
{
    public interface IProvideValues
    {
        T Find<T>() where T : class;
    }
}