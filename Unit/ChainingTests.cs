using Voluble;
using Voluble.Exceptions;

namespace Unit;

public class ChainingTests
{
    #region And Property Tests

    [Fact]
    public void And_ReturnsTheSameAssertion()
    {
        var assertion = "test".Should();
        var andResult = assertion.And;

        Assert.Same(assertion, andResult);
    }

    #endregion

    #region Basic Chaining Tests

    [Fact]
    public void Should_BeAbleToChainStringAssertions()
    {
        "hello world".Should()
            .NotBeNull()
            .And.Contain("hello")
            .And.Contain("world")
            .And.StartWith("hello")
            .And.EndWith("world");
    }

    [Fact]
    public void Should_BeAbleToChainWithoutAndKeyword()
    {
        "hello world".Should()
            .NotBeNull()
            .Contain("hello")
            .Contain("world")
            .StartWith("hello")
            .EndWith("world");
    }

    [Fact]
    public void Should_BeAbleToChainNullableAssertions()
    {
        string? value = "test";
        value.Should()
            .NotBeNull()
            .And.Contain("test");
    }

    [Fact]
    public void Should_BeAbleToChainBeExtension()
    {
        5.Should()
            .NotBeNull()
            .And.Be(5);
    }

    [Fact]
    public void Should_BeAbleToChainNotBeExtension()
    {
        5.Should()
            .NotBe(4)
            .And.NotBe(6);
    }

    #endregion

    #region Action Chaining Tests

    [Fact]
    public void Should_BeAbleToChainActionAssertions_NoException()
    {
        // When an action doesn't throw, we can chain assertions
        Action action = () => { var x = 1 + 1; };
        action.Should()
            .NotThrow<InvalidOperationException>()
            .And.NotThrow<ArgumentException>();
    }

    [Fact]
    public void Should_ReturnAssertionFromThrow()
    {
        // Throw returns the assertion which could be used for further checks
        Action action = () => throw new InvalidOperationException("test");
        var assertion = action.Should().Throw<InvalidOperationException>();
        Assert.NotNull(assertion);
    }
    
    [Fact]
    public void Should_ThrowWhenUnexceptedExceptionThrows()
    {
        // Throw returns the assertion which could be used for further checks
        Action action = () => throw new ArgumentException("test");
        var act = () => action.Should().Throw<InvalidOperationException>();

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region Async Action Chaining Tests

    [Fact]
    public async Task Should_BeAbleToChainAsyncAssertions()
    {
        Func<Task> asyncAction = () => Task.CompletedTask;
        var assertion = await asyncAction.Should()
            .NotThrowAsync<InvalidOperationException>();

        // After awaiting, we get back the assertion for potential further use
        Assert.NotNull(assertion);
    }

    [Fact]
    public async Task Should_BeAbleToChainNotThrowAsync()
    {
        Func<Task> asyncAction = () => Task.CompletedTask;
        await asyncAction.Should()
            .NotThrowAsync();
    }

    [Fact]
    public async Task Should_BeAbleToChainCompleteWithin()
    {
        Func<Task> asyncAction = () => Task.CompletedTask;
        await asyncAction.Should()
            .CompleteWithin(TimeSpan.FromSeconds(1));
    }

    #endregion

    #region Type Assertion Chaining Tests

    [Fact]
    public void Should_BeAbleToChainTypeAssertions()
    {
        object obj = "test";
        obj.Should()
            .NotBeNull()
            .And.BeOfType<string>()
            .And.BeAssignableTo<object>();
    }

    #endregion

    #region BeEquivalentTo Chaining Tests

    [Fact]
    public void Should_BeAbleToChainBeEquivalentTo()
    {
        var obj = new { Name = "John", Age = 30 };
        obj.Should()
            .NotBeNull()
            .And.BeEquivalentTo(new { Name = "John", Age = 30 });
    }

    #endregion

    #region String Extension Chaining Tests

    [Fact]
    public void Should_BeAbleToChainAllStringMethods()
    {
        "Hello World!".Should()
            .NotBeNullOrEmpty()
            .And.NotBeNullOrWhiteSpace()
            .And.HaveLength(12)
            .And.Contain("World")
            .And.StartWith("Hello")
            .And.EndWith("!")
            .And.Match("Hello.*!");
    }

    [Fact]
    public void Should_BeAbleToChainNegativeStringMethods()
    {
        "Hello World!".Should()
            .NotContain("Goodbye")
            .And.NotMatch("^Goodbye");
    }

    [Fact]
    public void Should_BeAbleToChainStringLengthMethods()
    {
        "Hello".Should()
            .HaveLengthGreaterThan(3)
            .And.HaveLengthLessThan(10);
    }

    #endregion

    #region Failure Collection with Chaining Tests

    [Fact]
    public void Should_CollectMultipleFailuresWhenChainingInScope()
    {
        // Using VolubleScope should collect all failures and throw at the end
        Assert.Throws<FailureCollection>(() =>
        {
            using var scope = new VolubleScope();
            "test".Should()
                .Contain("xyz")      // Fails
                .And.StartWith("abc"); // Fails
        });
    }

    #endregion
}
