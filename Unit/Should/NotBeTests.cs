using Voluble.Exceptions;

namespace Voluble.Unit.Should;

public class NotBeTests
{
    [Fact]
    public void NumbersEqualNumbers_ShouldThrow()
    {
        var act = () => 5.Should().NotBe(5);

        Assert.Throws<Failure>(act);
    }
    
    [Fact]
    public void NumbersNotEqual_ShouldNotThrow()
    {
        var act = () => 5.Should().NotBe(6);
        
        var throws = false;
        try
        {
            act();
        }
        catch (Exception)
        {
            throws = true;
        }
        Assert.False(throws);
    }
}