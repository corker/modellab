using ModelLab.Actions;
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
            Session.Run(x => x
                .UseLogger(_helper)
                .Use<ActionLogger>()
                .UseGraphml()
                .UseModel(m => m
                    .GraphmlEmbeddedResource("Models/SimpleModel.graphml")
                    .RandomAlgorithm()
                    .Length(2)
                )
            );
        }
    }
}