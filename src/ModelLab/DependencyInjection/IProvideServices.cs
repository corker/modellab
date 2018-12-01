using System;
using System.Collections.Generic;

namespace ModelLab
{
    public interface IProvideServices
    {
        object Get(Type type);
        IEnumerable<object> GetAll(Type type);
    }
}