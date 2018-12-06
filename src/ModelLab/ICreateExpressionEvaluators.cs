namespace ModelLab
{
    public interface ICreateExpressionEvaluators
    {
        IEvaluateExpressions Create(IAmModel[] models);
    }
}