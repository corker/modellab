namespace ModelLab
{
    public interface ICreateStopConditions
    {
        IEvaluateStopConditions Create(IAmModel[] models);
    }
}