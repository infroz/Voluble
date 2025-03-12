using Voluble.Exceptions;

namespace Voluble.Unit.Should;

public class ObjectTests
{
    [Fact]
    public void BeNull_NullObject_DoesNotThrow()
    {
        string? obj = null;
        var act = () => obj.Should().BeNull();
        
        var thrown = false;
        try
        {
            act.Invoke();
        }
        catch (Exception)
        {
            thrown = true;
        }
        
        Assert.False(thrown);
    }

    [Fact]
    public void BeNull_NotNullObject_DoesThrow()
    {
        var obj = new object();
        var act = () => obj.Should().BeNull();
        Assert.Throws<Failure>(act);
    }
    
    [Fact]
    public void NotBeNull_NullObject_DoesThrow()
    {
        string? obj = null;
        var act = () => obj.Should().NotBeNull();
        Assert.Throws<Failure>(act);
    }
    
    [Fact]
    public void NotBeNull_NotNullObject_DoesNotThrow()
    {
        var obj = new object();
        var act = () => obj.Should().NotBeNull();
        
        bool thrown = false;
        try
        {
            act.Invoke();
        }
        catch (Exception)
        {
            thrown = true;
        }
        
        Assert.False(thrown);
    }
}