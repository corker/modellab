using System.Threading.Tasks;
using ModelLab.Examples.Xunit.Models;
using ModelLab.Graphml;
using ModelLab.Xunit;
using Xunit;
using Xunit.Abstractions;

namespace ModelLab.Examples.Xunit
{
    public class SimpleModelTest
    {
        public SimpleModelTest(ITestOutputHelper helper)
        {
            _helper = helper;
        }

        private readonly ITestOutputHelper _helper;

        [Fact]
        public async Task Run()
        {
            await ModelRunner.RunAsync(c => c
                .UseLogger(_helper)
                .UseGraphml()
                .UseEmbeddedResource<GraphmlModel>("Models/SimpleModel.graphml")
                .UseModelImplementation<SimpleModel>()
            );
        }
    }
}