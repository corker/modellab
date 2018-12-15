using System.Collections.Generic;

namespace ModelLab.StopConditions
{
    public class LengthStopCondition : IEvaluateStopConditions
    {
        private readonly List<object> _sequence;
        private readonly int _value;

        public LengthStopCondition(int value)
        {
            _value = value;
            _sequence = new List<object>();
        }

        public bool Evaluate(IAmGraphNode node, IProvideSessionState state)
        {
            _sequence.Add(node);
            return _sequence.Count > _value;
        }

        public bool Evaluate(IAmGraphEdge edge, IProvideSessionState state)
        {
            _sequence.Add(edge);
            return _sequence.Count > _value;
        }
    }
}