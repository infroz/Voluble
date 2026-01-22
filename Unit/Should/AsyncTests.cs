using Voluble.Exceptions;

namespace Voluble.Unit.Should;

public class AsyncTests
{
    #region ThrowAsync

    [Fact]
    public async Task ThrowAsync_WhenThrowsExpectedException_ShouldNotThrow()
    {
        Func<Task> action = async () =>
        {
            await Task.Delay(1);
            throw new InvalidOperationException("Test");
        };

        var exception = await Record.ExceptionAsync(() => action.Should().ThrowAsync<InvalidOperationException>());
        Assert.Null(exception);
    }

    [Fact]
    public async Task ThrowAsync_WhenDoesNotThrow_ShouldFail()
    {
        Func<Task> action = async () =>
        {
            await Task.Delay(1);
        };

        await Assert.ThrowsAsync<Failure>(() => action.Should().ThrowAsync<InvalidOperationException>());
    }

    [Fact]
    public async Task ThrowAsync_WhenThrowsDifferentException_ShouldFail()
    {
        Func<Task> action = async () =>
        {
            await Task.Delay(1);
            throw new ArgumentException("Test");
        };

        await Assert.ThrowsAsync<Failure>(() => action.Should().ThrowAsync<InvalidOperationException>());
    }

    [Fact]
    public async Task ThrowAsync_WhenThrowsDerivedExceptionAndExpectingBase_ShouldNotThrow()
    {
        Func<Task> action = async () =>
        {
            await Task.Delay(1);
            throw new ArgumentNullException("param");
        };

        // ArgumentNullException derives from ArgumentException
        var exception = await Record.ExceptionAsync(() => action.Should().ThrowAsync<ArgumentException>());
        Assert.Null(exception);
    }

    #endregion

    #region NotThrowAsync<TException>

    [Fact]
    public async Task NotThrowAsyncGeneric_WhenDoesNotThrow_ShouldNotThrow()
    {
        Func<Task> action = async () =>
        {
            await Task.Delay(1);
        };

        var exception = await Record.ExceptionAsync(() => action.Should().NotThrowAsync<InvalidOperationException>());
        Assert.Null(exception);
    }

    [Fact]
    public async Task NotThrowAsyncGeneric_WhenThrowsExpectedException_ShouldFail()
    {
        Func<Task> action = async () =>
        {
            await Task.Delay(1);
            throw new InvalidOperationException("Test");
        };

        await Assert.ThrowsAsync<Failure>(() => action.Should().NotThrowAsync<InvalidOperationException>());
    }

    [Fact]
    public async Task NotThrowAsyncGeneric_WhenThrowsDifferentException_ShouldNotFail()
    {
        Func<Task> action = async () =>
        {
            await Task.Delay(1);
            throw new ArgumentException("Test");
        };

        // Should not fail because we're checking for InvalidOperationException specifically
        var exception = await Record.ExceptionAsync(() => action.Should().NotThrowAsync<InvalidOperationException>());
        Assert.Null(exception);
    }

    #endregion

    #region NotThrowAsync (non-generic)

    [Fact]
    public async Task NotThrowAsync_WhenDoesNotThrow_ShouldNotThrow()
    {
        Func<Task> action = async () =>
        {
            await Task.Delay(1);
        };

        var exception = await Record.ExceptionAsync(() => action.Should().NotThrowAsync());
        Assert.Null(exception);
    }

    [Fact]
    public async Task NotThrowAsync_WhenThrowsAnyException_ShouldFail()
    {
        Func<Task> action = async () =>
        {
            await Task.Delay(1);
            throw new Exception("Test");
        };

        await Assert.ThrowsAsync<Failure>(() => action.Should().NotThrowAsync());
    }

    [Fact]
    public async Task NotThrowAsync_WhenThrowsSpecificException_ShouldFail()
    {
        Func<Task> action = async () =>
        {
            await Task.Delay(1);
            throw new InvalidOperationException("Test");
        };

        await Assert.ThrowsAsync<Failure>(() => action.Should().NotThrowAsync());
    }

    #endregion

    #region CompleteWithin

    [Fact]
    public async Task CompleteWithin_WhenCompletesInTime_ShouldNotThrow()
    {
        Func<Task> action = async () =>
        {
            await Task.Delay(10);
        };

        var exception = await Record.ExceptionAsync(() => action.Should().CompleteWithin(TimeSpan.FromSeconds(5)));
        Assert.Null(exception);
    }

    [Fact]
    public async Task CompleteWithin_WhenTimesOut_ShouldFail()
    {
        Func<Task> action = async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
        };

        await Assert.ThrowsAsync<Failure>(() => action.Should().CompleteWithin(TimeSpan.FromMilliseconds(50)));
    }

    [Fact]
    public async Task CompleteWithin_WhenCompletesImmediately_ShouldNotThrow()
    {
        Func<Task> action = () => Task.CompletedTask;

        var exception = await Record.ExceptionAsync(() => action.Should().CompleteWithin(TimeSpan.FromSeconds(1)));
        Assert.Null(exception);
    }

    [Fact]
    public async Task CompleteWithin_WhenTaskThrowsException_ShouldPropagateException()
    {
        Func<Task> action = async () =>
        {
            await Task.Delay(1);
            throw new InvalidOperationException("Test error");
        };

        // The exception should propagate since the task completed (with an error) within the timeout
        await Assert.ThrowsAsync<InvalidOperationException>(() => action.Should().CompleteWithin(TimeSpan.FromSeconds(5)));
    }

    #endregion

    #region ThrowAsyncAndReturn

    [Fact]
    public async Task ThrowAsyncAndReturn_WhenThrows_ShouldReturnException()
    {
        var expectedMessage = "Test error message";
        Func<Task> action = async () =>
        {
            await Task.Delay(1);
            throw new InvalidOperationException(expectedMessage);
        };

        var exception = await action.Should().ThrowAsyncAndReturn<InvalidOperationException>();

        Assert.NotNull(exception);
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public async Task ThrowAsyncAndReturn_WhenDoesNotThrow_ShouldFail()
    {
        Func<Task> action = async () =>
        {
            await Task.Delay(1);
        };

        await Assert.ThrowsAsync<Failure>(() => action.Should().ThrowAsyncAndReturn<InvalidOperationException>());
    }

    [Fact]
    public async Task ThrowAsyncAndReturn_CanInspectExceptionProperties()
    {
        var paramName = "testParam";
        Func<Task> action = async () =>
        {
            await Task.Delay(1);
            throw new ArgumentNullException(paramName);
        };

        var exception = await action.Should().ThrowAsyncAndReturn<ArgumentNullException>();

        Assert.Equal(paramName, exception.ParamName);
    }

    #endregion

    #region Edge Cases

    [Fact]
    public async Task ThrowAsync_WithSynchronousException_ShouldCatch()
    {
        Func<Task> action = () => throw new InvalidOperationException("Sync throw");

        var exception = await Record.ExceptionAsync(() => action.Should().ThrowAsync<InvalidOperationException>());
        Assert.Null(exception);
    }

    [Fact]
    public async Task NotThrowAsync_WithValueTask_CanBeConverted()
    {
        // Show that ValueTask can be converted to Task for assertion
        Func<Task> action = async () =>
        {
            await new ValueTask();
        };

        var exception = await Record.ExceptionAsync(() => action.Should().NotThrowAsync());
        Assert.Null(exception);
    }

    #endregion
}
