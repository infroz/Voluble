using Voluble.Exceptions;

namespace Voluble.Unit.Should;

public class NotThrowTests
{
    [Fact]
    public void ShouldNotThrow()
    {
        // Arrange
        var action = () => { return 5; };
        // Act

        // Assert
        action.Should().NotThrow<Exception>();
    }
    
    [Fact]
    public void ShouldThrow()
    {
        // Arrange
        var action = () => { throw new Exception("Test"); };
        // Act

        // Assert
        var act = () => action.Should().NotThrow<Exception>();
        Assert.Throws<Failure>(act);
    }
}