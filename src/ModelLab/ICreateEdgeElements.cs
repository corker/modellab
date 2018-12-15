namespace ModelLab
{
    public interface ICreateEdgeElements
    {
        IIterateElements TryCreateFrom(IAmGraphEdge edge);
    }
}