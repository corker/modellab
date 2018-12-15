namespace ModelLab
{
    public interface IProvideEdgeElements
    {
        IIterateElements Find(IAmGraphNode node, IProvideSessionState state);
    }
}