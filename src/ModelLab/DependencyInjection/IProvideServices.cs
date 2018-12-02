using System;
using System.Collections.Generic;

namespace ModelLab.DependencyInjection
{
    public interface IProvideServices
    {
        object Get(Type type);
        IEnumerable<object> GetAll(Type type);
    }
}