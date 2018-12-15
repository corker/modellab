using ModelLab.Elements;
using ModelLab.Graphs;
using ModelLab.Infrastructure;

namespace ModelLab.Actions
{
    public class ActionLogger : IExecuteActions
    {
        private readonly IWriteLogs _logs;

        public ActionLogger(IWriteLogs logs)
        {
            _logs = logs;
        }

        public void ExecuteFor(IAmElement element)
        {
            var values = (IProvideValues) element;
            var arguments = values.Get<IAmActionArguments>();
            _logs.Write(arguments.ActionName);
        }
    }
}