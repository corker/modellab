namespace ModelLab
{
    public interface IEvaluateStopConditions
    {
        bool Evaluate(IAmScenarioState state);
    }
}