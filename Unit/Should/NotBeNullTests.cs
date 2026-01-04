using Voluble.Exceptions;

namespace Voluble.Unit.Should;

public class NotBeNullTests
{
    [Fact]
    public void NotBeNull_IsNotNull_WhenValueIsNotNull()
    {
        const string value = "not null";
       
        // Argument of type 'Voluble.VolubleAsserrtion<string>' cannot be used for parameter 'asserrtion' of type 'Voluble.VolubleAsserrtion<string?>' in 'Voluble.ObjectExtension.NotBeNull<TObject>' because of differences in the nullability of reference types
        // ^^ above is the warning received on the line below, I'd like the following example to be valid code even on nullable types
        try
        {
            Act();
        }
        catch (Exception e)
        {
            Assert.Null(e);
        }

        return;
        void Act() => value.Should().NotBeNull();
    }

    [Fact]
    public void NotBeNull_IsNotNull_WhenValueIsNull()
    {
        string? value = null;
        Assert.Throws<Failure>(Act);

        return;
        void Act() => value.Should().NotBeNull();
    }
}