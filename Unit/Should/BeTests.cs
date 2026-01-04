using Voluble.Exceptions;

namespace Voluble.Unit.Should;

public class BeTests
{
    [Fact]
    public void Be_CanChainNullable_WhenValueIsNullable()
    {
        string? value = null;
        
        var act = () => value.Should().Be(null);
        
    }
    
    [Fact]
    public void NumbersEqualNumbers_ShouldNotThrow()
    {
        var act = () => 5.Should().Be(5);

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
    
    [Fact]
    public void NumbersNotEqual_ShouldThrow()
    {
        var act = () => 5.Should().Be(6);

        Assert.Throws<Failure>(act);
    }
}