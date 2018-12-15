namespace ModelLab
{
    public interface IProvideNodeElements
    {
        IIterateElements FindByName(string name);
        IIterateElements FindTargetFor(IAmGraphEdge edge);
    }
}