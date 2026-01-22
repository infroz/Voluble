namespace Voluble;

/// <summary>
/// Extension methods for async action assertions.
/// </summary>
public static class AsyncActionExtension
{
    /// <summary>
    /// Asserts that the async action throws the specified exception type.
    /// </summary>
    public static async Task ThrowAsync<TException>(this VolubleAssertion<Func<Task>> assertion)
        where TException : Exception
    {
        if (assertion.Obj is null)
        {
            throw new ArgumentException("Expected an async action to be passed");
        }

        Exception? caught = null;
        try
        {
            await assertion.Obj();
        }
        catch (Exception ex)
        {
            caught = ex;
        }

        if (caught is not TException)
        {
            if (caught is null)
                VolubleScope.FailWith($"Expected {typeof(TException).Name} to be thrown but no exception was thrown");
            else
                VolubleScope.FailWith($"Expected {typeof(TException).Name} to be thrown but {caught.GetType().Name} was thrown");
        }
    }

    /// <summary>
    /// Asserts that the async action does not throw the specified exception type.
    /// </summary>
    public static async Task NotThrowAsync<TException>(this VolubleAssertion<Func<Task>> assertion)
        where TException : Exception
    {
        if (assertion.Obj is null)
        {
            throw new ArgumentException("Expected an async action to be passed");
        }

        Exception? caught = null;
        try
        {
            await assertion.Obj();
        }
        catch (Exception ex)
        {
            caught = ex;
        }

        if (caught is TException)
            VolubleScope.FailWith($"Expected no {typeof(TException).Name} to be thrown, but it was");
    }

    /// <summary>
    /// Asserts that the async action does not throw any exception.
    /// </summary>
    public static async Task NotThrowAsync(this VolubleAssertion<Func<Task>> assertion)
    {
        if (assertion.Obj is null)
        {
            throw new ArgumentException("Expected an async action to be passed");
        }

        Exception? caught = null;
        try
        {
            await assertion.Obj();
        }
        catch (Exception ex)
        {
            caught = ex;
        }

        if (caught is not null)
            VolubleScope.FailWith($"Expected no exception to be thrown, but {caught.GetType().Name} was thrown: {caught.Message}");
    }

    /// <summary>
    /// Asserts that the async action completes within the specified timeout.
    /// </summary>
    public static async Task CompleteWithin(this VolubleAssertion<Func<Task>> assertion, TimeSpan timeout)
    {
        if (assertion.Obj is null)
        {
            throw new ArgumentException("Expected an async action to be passed");
        }

        using var cts = new CancellationTokenSource();
        var task = assertion.Obj();
        var delayTask = Task.Delay(timeout, cts.Token);

        var completedTask = await Task.WhenAny(task, delayTask);

        if (completedTask == delayTask)
        {
            VolubleScope.FailWith($"Expected task to complete within {timeout} but it did not");
        }
        else
        {
            // Cancel the delay task since the main task completed
            await cts.CancelAsync();
            // Await the task to propagate any exceptions
            await task;
        }
    }

    /// <summary>
    /// Asserts that the async action throws the specified exception type and returns the exception.
    /// </summary>
    public static async Task<TException> ThrowAsyncAndReturn<TException>(this VolubleAssertion<Func<Task>> assertion)
        where TException : Exception
    {
        if (assertion.Obj is null)
        {
            throw new ArgumentException("Expected an async action to be passed");
        }

        Exception? caught = null;
        try
        {
            await assertion.Obj();
        }
        catch (Exception ex)
        {
            caught = ex;
        }

        if (caught is not TException typedException)
        {
            if (caught is null)
                VolubleScope.FailWith($"Expected {typeof(TException).Name} to be thrown but no exception was thrown");
            else
                VolubleScope.FailWith($"Expected {typeof(TException).Name} to be thrown but {caught.GetType().Name} was thrown");

            throw new InvalidOperationException("Unreachable");
        }

        return typedException;
    }
}
