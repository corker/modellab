using System.Reflection;
using FluentAssertions;
using Xunit;

namespace ModelLab.UnitTests.Domain
{
    public class EmbeddedResourceExtensionsTests
    {
        [Theory]
        [InlineData("models/simple-model.graphml", "ModelLab.UnitTests.models.simple-model.graphml")]
        [InlineData("models/simple/model.graphml", "ModelLab.UnitTests.models.simple.model.graphml")]
        public void AsEmbeddedResourceName_ShouldReturnExpected(string value, string expected)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var result = value.AsEmbeddedResourceName(assembly);
            result.Should().Be(expected);
        }
    }
}