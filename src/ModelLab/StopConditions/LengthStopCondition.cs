using System.Collections.Generic;
using ModelLab.Graphs;

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

        public bool Evaluate(IAmNode node)
        {
            _sequence.Add(node);
            return _sequence.Count > _value;
        }

        public bool Evaluate(IAmEdge edge)
        {
            _sequence.Add(edge);
            return _sequence.Count > _value;
        }
    }
}