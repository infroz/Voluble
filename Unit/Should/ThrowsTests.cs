namespace Voluble.Unit.Should;

public class ThrowsTests
{
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
        var act = () => { return 5; };

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