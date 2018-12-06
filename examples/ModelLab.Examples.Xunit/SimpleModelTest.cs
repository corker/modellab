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
        public void Run()
        {
            Scenario.Run(x => x
                .UseLogger(_helper)
                .UseGraphml()
                .UseModel(m => m
                    .EmbeddedResource<GraphmlGraph>("Models/SimpleModel.graphml")
                    .Random(c => c.EdgeCoverage(100))
                    .Implementation<SimpleModel>()
                )
            );
        }
    }
}