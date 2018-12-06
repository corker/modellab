namespace ModelLab
{
    public interface IEvaluateExpressions
    {
        bool EvaluateGuard(IAmGraphEdge edge, IAmScenarioState state);
        IAmScenarioState EvaluateAction(IAmGraphNode node, IAmScenarioState state);
        IAmScenarioState EvaluateAction(IAmGraphEdge edge, IAmScenarioState state);
    }
}