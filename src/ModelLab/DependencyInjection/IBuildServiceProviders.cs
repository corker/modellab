using System;

namespace ModelLab.DependencyInjection
{
    public interface IBuildServiceProviders
    {
        IProvideServices Build();
        IBuildServiceProviders Register(Type type, ICreateServices services);
    }
}