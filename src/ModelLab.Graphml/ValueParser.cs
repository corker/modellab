using System;
using System.Collections.Generic;
using ModelLab.Actions;
using ModelLab.Graphs;

namespace ModelLab.Graphml
{
    public class ValueParser : IParseValues
    {
        public IProvideValues Parse(string value)
        {
            var objects = new Dictionary<Type, object>
            {
                {
                    typeof(IAmActionArguments), new ActionArguments
                    {
                        ActionName = value
                    }
                }
            };
            return new Values(objects);
        }

        public class ActionArguments : IAmActionArguments
        {
            public string ActionName { get; set; }
        }

        private class Values : IProvideValues
        {
            private readonly Dictionary<Type, object> _objects;

            public Values(Dictionary<Type, object> objects)
            {
                _objects = objects;
            }

            public T Find<T>() where T : class
            {
                if (_objects.TryGetValue(typeof(T), out var value)) return (T) value;
                return null;
            }
        }
    }
}