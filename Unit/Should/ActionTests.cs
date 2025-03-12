using Voluble.Exceptions;

namespace Voluble.Unit.Should;

public class ActionTests
{
    [Fact]
    public void ShouldNotThrow()
    {
        var method = () => { return 5; };
        
        // Arrange
        var action = () => { method(); };
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
    
    
    [Fact]
    public void ExpectActionThrow_VolubleDoes()
    {
        Action act = () => throw new Exception("Test");

        Action act2 = () => act.Should().Throw<Exception>();

        var throws = false;
        try
        {
            act2();
        }
        catch (Exception)
        {
            throws = true;
        }
        
        Assert.False(throws);
    }
    
    [Fact]
    public void ActionSucceeds_VolubleExpectsException()
    {
        var act = () => { };

        var act2 = () => act.Should().Throw<Exception>();

        var throws = false;
        try
        {
            act2();
        }
        catch (Exception)
        {
            throws = true;
        }
        
        Assert.True(throws);
    }
}