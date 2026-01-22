using Voluble.Exceptions;

namespace Voluble.Unit.Should;

public class StringTests
{
    #region Contain

    [Fact]
    public void Contain_WhenStringContainsSubstring_ShouldNotThrow()
    {
        var act = () => "hello world".Should().Contain("world");

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void Contain_WhenStringDoesNotContainSubstring_ShouldThrow()
    {
        var act = () => "hello".Should().Contain("world");

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void Contain_WhenStringIsNull_ShouldThrow()
    {
        string? value = null;
        var act = () => value.Should().Contain("test");

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region NotContain

    [Fact]
    public void NotContain_WhenStringDoesNotContainSubstring_ShouldNotThrow()
    {
        var act = () => "hello".Should().NotContain("world");

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotContain_WhenStringContainsSubstring_ShouldThrow()
    {
        var act = () => "hello world".Should().NotContain("world");

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void NotContain_WhenStringIsNull_ShouldNotThrow()
    {
        string? value = null;
        var act = () => value.Should().NotContain("test");

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region StartWith

    [Fact]
    public void StartWith_WhenStringStartsWithPrefix_ShouldNotThrow()
    {
        var act = () => "hello world".Should().StartWith("hello");

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void StartWith_WhenStringDoesNotStartWithPrefix_ShouldThrow()
    {
        var act = () => "hello world".Should().StartWith("world");

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void StartWith_WhenStringIsNull_ShouldThrow()
    {
        string? value = null;
        var act = () => value.Should().StartWith("test");

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region EndWith

    [Fact]
    public void EndWith_WhenStringEndsWithSuffix_ShouldNotThrow()
    {
        var act = () => "hello world".Should().EndWith("world");

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void EndWith_WhenStringDoesNotEndWithSuffix_ShouldThrow()
    {
        var act = () => "hello world".Should().EndWith("hello");

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void EndWith_WhenStringIsNull_ShouldThrow()
    {
        string? value = null;
        var act = () => value.Should().EndWith("test");

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region Match

    [Fact]
    public void Match_WhenStringMatchesPattern_ShouldNotThrow()
    {
        var act = () => "test123".Should().Match(@"\w+\d+");

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void Match_WhenStringDoesNotMatchPattern_ShouldThrow()
    {
        var act = () => "test".Should().Match(@"^\d+$");

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void Match_WhenStringIsNull_ShouldThrow()
    {
        string? value = null;
        var act = () => value.Should().Match(@"\w+");

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void Match_WithEmailPattern_ShouldWork()
    {
        var act = () => "user@example.com".Should().Match(@"^[\w.-]+@[\w.-]+\.\w+$");

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region NotMatch

    [Fact]
    public void NotMatch_WhenStringDoesNotMatchPattern_ShouldNotThrow()
    {
        var act = () => "test".Should().NotMatch(@"^\d+$");

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotMatch_WhenStringMatchesPattern_ShouldThrow()
    {
        var act = () => "123".Should().NotMatch(@"^\d+$");

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void NotMatch_WhenStringIsNull_ShouldNotThrow()
    {
        string? value = null;
        var act = () => value.Should().NotMatch(@"\w+");

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region BeNullOrEmpty

    [Fact]
    public void BeNullOrEmpty_WhenStringIsNull_ShouldNotThrow()
    {
        string? value = null;
        var act = () => value.Should().BeNullOrEmpty();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeNullOrEmpty_WhenStringIsEmpty_ShouldNotThrow()
    {
        var act = () => "".Should().BeNullOrEmpty();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeNullOrEmpty_WhenStringHasValue_ShouldThrow()
    {
        var act = () => "hello".Should().BeNullOrEmpty();

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region NotBeNullOrEmpty

    [Fact]
    public void NotBeNullOrEmpty_WhenStringHasValue_ShouldNotThrow()
    {
        var act = () => "hello".Should().NotBeNullOrEmpty();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotBeNullOrEmpty_WhenStringIsNull_ShouldThrow()
    {
        string? value = null;
        var act = () => value.Should().NotBeNullOrEmpty();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void NotBeNullOrEmpty_WhenStringIsEmpty_ShouldThrow()
    {
        var act = () => "".Should().NotBeNullOrEmpty();

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region BeNullOrWhiteSpace

    [Fact]
    public void BeNullOrWhiteSpace_WhenStringIsNull_ShouldNotThrow()
    {
        string? value = null;
        var act = () => value.Should().BeNullOrWhiteSpace();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeNullOrWhiteSpace_WhenStringIsEmpty_ShouldNotThrow()
    {
        var act = () => "".Should().BeNullOrWhiteSpace();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeNullOrWhiteSpace_WhenStringIsWhitespace_ShouldNotThrow()
    {
        var act = () => "   ".Should().BeNullOrWhiteSpace();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeNullOrWhiteSpace_WhenStringHasValue_ShouldThrow()
    {
        var act = () => "hello".Should().BeNullOrWhiteSpace();

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region NotBeNullOrWhiteSpace

    [Fact]
    public void NotBeNullOrWhiteSpace_WhenStringHasValue_ShouldNotThrow()
    {
        var act = () => "hello".Should().NotBeNullOrWhiteSpace();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotBeNullOrWhiteSpace_WhenStringIsNull_ShouldThrow()
    {
        string? value = null;
        var act = () => value.Should().NotBeNullOrWhiteSpace();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void NotBeNullOrWhiteSpace_WhenStringIsWhitespace_ShouldThrow()
    {
        var act = () => "   ".Should().NotBeNullOrWhiteSpace();

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region HaveLength

    [Fact]
    public void HaveLength_WhenStringHasExpectedLength_ShouldNotThrow()
    {
        var act = () => "hello".Should().HaveLength(5);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void HaveLength_WhenStringHasDifferentLength_ShouldThrow()
    {
        var act = () => "hello".Should().HaveLength(10);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void HaveLength_WhenStringIsNull_ShouldThrow()
    {
        string? value = null;
        var act = () => value.Should().HaveLength(5);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void HaveLength_WhenEmptyStringExpectsZero_ShouldNotThrow()
    {
        var act = () => "".Should().HaveLength(0);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region HaveLengthGreaterThan

    [Fact]
    public void HaveLengthGreaterThan_WhenStringIsLonger_ShouldNotThrow()
    {
        var act = () => "hello".Should().HaveLengthGreaterThan(3);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void HaveLengthGreaterThan_WhenStringIsShorterOrEqual_ShouldThrow()
    {
        var act = () => "hello".Should().HaveLengthGreaterThan(5);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void HaveLengthGreaterThan_WhenStringIsNull_ShouldThrow()
    {
        string? value = null;
        var act = () => value.Should().HaveLengthGreaterThan(0);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region HaveLengthLessThan

    [Fact]
    public void HaveLengthLessThan_WhenStringIsShorter_ShouldNotThrow()
    {
        var act = () => "hello".Should().HaveLengthLessThan(10);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void HaveLengthLessThan_WhenStringIsLongerOrEqual_ShouldThrow()
    {
        var act = () => "hello".Should().HaveLengthLessThan(5);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void HaveLengthLessThan_WhenStringIsNull_ShouldThrow()
    {
        string? value = null;
        var act = () => value.Should().HaveLengthLessThan(10);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region BeEquivalentTo

    [Fact]
    public void BeEquivalentTo_WhenStringsAreEqualIgnoringCase_ShouldNotThrow()
    {
        var act = () => "Hello World".Should().BeEquivalentTo("hello world");

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeEquivalentTo_WhenStringsAreDifferent_ShouldThrow()
    {
        var act = () => "hello".Should().BeEquivalentTo("world");

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeEquivalentTo_WhenBothAreNull_ShouldNotThrow()
    {
        string? value = null;
        var act = () => value.Should().BeEquivalentTo(null);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeEquivalentTo_WhenOneIsNull_ShouldThrow()
    {
        string? value = null;
        var act = () => value.Should().BeEquivalentTo("hello");

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeEquivalentTo_WithOrdinalComparison_ShouldBeCaseSensitive()
    {
        var act = () => "Hello".Should().BeEquivalentTo("hello", StringComparison.Ordinal);

        Assert.Throws<Failure>(act);
    }

    #endregion
}
