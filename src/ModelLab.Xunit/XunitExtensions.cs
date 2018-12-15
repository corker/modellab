using ModelLab.DependencyInjection;
using ModelLab.Infrastructure;
using Xunit.Abstractions;

namespace ModelLab.Xunit
{
    public static class XunitExtensions
    {
        public static IRegisterServices UseLogger(this IRegisterServices resolvers, ITestOutputHelper helper)
        {
            var logger = new Logger(helper);
            resolvers.Use<IWriteLogs>(logger);
            return resolvers;
        }

        private class Logger : IWriteLogs
        {
            private readonly ITestOutputHelper _helper;

            public Logger(ITestOutputHelper helper)
            {
                _helper = helper;
            }

            public void Write(string format, params object[] args)
            {
                _helper.WriteLine(format, args);
            }
        }
    }
}