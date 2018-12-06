using System;
using ModelLab.Configuration;
using ModelLab.Providers;

namespace ModelLab
{
    public class ModelBuilder :
        IConfigureModels,
        IConfigureGenerators,
        IConfigureImplementations,
        IBuildModels
    {
        private readonly Action<IConfigureModels> _action;

        public ModelBuilder(Action<IConfigureModels> action)
        {
            _action = action;
        }

        public IAmModel Build()
        {
            throw new NotImplementedException();
        }

        public IConfigureImplementations Use(IProvideGenerators generators)
        {
            throw new NotImplementedException();
        }

        public IConfigureImplementations Use(IProvideImplementations implementations)
        {
            throw new NotImplementedException();
        }

        public IConfigureGenerators Use(IProvideGraphs graphs)
        {
            throw new NotImplementedException();
        }
    }
}