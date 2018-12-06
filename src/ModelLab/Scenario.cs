using System;
using System.Collections.Generic;
using System.Linq;
using ModelLab.DependencyInjection;

namespace ModelLab
{
    public class Scenario : IRunScenarios
    {
        private readonly ICreateEdgeChoosingAlgorithms _algorithms;
        private readonly ICreateStopConditions _conditions;
        private readonly ICreateExpressionEvaluators _evaluators;
        private readonly IEnumerable<IBuildModels> _models;
        private readonly ICreateModelNavigators _navigators;
        private readonly IAmScenarioSettings _settings;

        public Scenario(
            IProvideServices services,
            IAmScenarioSettings settings,
            ICreateModelNavigators navigators,
            ICreateExpressionEvaluators evaluators,
            ICreateStopConditions conditions,
            ICreateEdgeChoosingAlgorithms algorithms
        )
        {
            _settings = settings;
            _navigators = navigators;
            _evaluators = evaluators;
            _conditions = conditions;
            _algorithms = algorithms;
            _models = services.GetAll<IBuildModels>();
        }

        public void Run()
        {
            var models = _models.Select(x => x.Build()).ToArray();
            var navigator = _navigators.Create(models);
            var evaluator = _evaluators.Create(models);
            var condition = _conditions.Create(models);
            var algorithm = _algorithms.Create(models);
            var node = navigator.GetNode(_settings.StartNodeName);
            var state = evaluator.EvaluateAction(node, null);
            while (!condition.Evaluate(state))
            {
                var edges = navigator.GetEdges(node).Where(x => evaluator.EvaluateGuard(x, state)).ToArray();
                var edge = algorithm.Choose(edges);
                state = evaluator.EvaluateAction(edge, state);
                node = navigator.GetNode(edge);
                state = evaluator.EvaluateAction(node, state);
            }
        }

        public static void Run(Action<IBuildServiceProviders> configure)
        {
            var builder = new ServiceRegistryBuilder();
            builder.Register<Scenario>();
            configure(builder);
            var services = builder.Build();
            var scenarios = services.Get<IRunScenarios>();
            scenarios.Run();
        }
    }
}