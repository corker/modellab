using System.Threading.Tasks;
using ModelLab.Examples.Xunit.Models;
using ModelLab.Xunit;
using Xunit;
using Xunit.Abstractions;

namespace ModelLab.Examples.Xunit
{
    public class UnitTest1
    {
        public UnitTest1(ITestOutputHelper helper)
        {
            _helper = helper;
        }

        private readonly ITestOutputHelper _helper;

        [Fact]
        public async Task Test1()
        {
            await ModelRunner.RunAsync(c => c
                .Use(_helper)
                .UseEmbeddedResource<GraphmlModel>("Models/SimpleModel.graphml")
                .UseModelImplementation<SimpleModel>()
            );
        }
    }
}