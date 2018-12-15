using System;
using ModelLab.DependencyInjection;

namespace ModelLab
{
    public static partial class Extensions
    {
        public static IRegisterServices UseModel(this IRegisterServices x, Action<IRegisterServices> action)
        {
            var resolver = new ServiceResolverOfModel(action);
            return x.Register(typeof(IProvideNodeElements), resolver);
        }

        public static IRegisterServices UseSettings(this IRegisterServices x, Action<SessionSettings> action)
        {
            var settings = new SessionSettings();
            action?.Invoke(settings);
            return x.Use<IProvideSessionSettings>(settings);
        }
    }
}