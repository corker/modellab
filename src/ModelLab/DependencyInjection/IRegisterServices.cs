using System;

namespace ModelLab.DependencyInjection
{
    public interface IRegisterServices
    {
        IRegisterServices Register(Type type, IResolveServices services);
    }
}