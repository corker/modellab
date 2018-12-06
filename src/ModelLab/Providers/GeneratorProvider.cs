using System;
using ModelLab.StopConditions;

namespace ModelLab
{
    public class GeneratorProvider<T> : IProvideGenerators
    {
        public GeneratorProvider(Func<IVerifyStopConditions, bool> condition)
        {
            throw new NotImplementedException();
        }
    }
}