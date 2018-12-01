using ModelLab.DependencyInjection;
using Xunit.Abstractions;

namespace ModelLab.Xunit
{
    public static class XunitExtensions
    {
        public static IBuildServiceProviders Use(this IBuildServiceProviders providers, ITestOutputHelper helper)
        {
            var logger = new Logger(helper);
            providers.Register<IWriteLogs>(logger);
            return providers;
        }

        private class Logger : IWriteLogs
        {
            private readonly ITestOutputHelper _helper;

            public Logger(ITestOutputHelper helper)
            {
                _helper = helper;
            }
        }
    }
}