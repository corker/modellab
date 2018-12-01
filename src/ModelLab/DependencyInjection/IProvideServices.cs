using System;

namespace ModelLab
{
    public interface IProvideServices
    {
        object Get(Type type);
    }
}