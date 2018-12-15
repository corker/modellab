namespace ModelLab
{
    public interface ICreateNodeElements
    {
        IIterateElements TryCreateFrom(IAmGraphNode node);
    }
}