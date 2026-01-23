namespace Voluble;

/// <summary>
/// Extension methods for async action assertions.
/// </summary>
public static class AsyncActionExtension
{
    /// <summary>
    /// Asserts that the async action throws the specified exception type.
    /// </summary>
    public static async Task<VolubleAssertion<Func<Task>>> ThrowAsync<TException>(this VolubleAssertion<Func<Task>> assertion, string? because = null)
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
                VolubleScope.FailWith($"Expected {typeof(TException).Name} to be thrown but no exception was thrown", because);
            else
                VolubleScope.FailWith($"Expected {typeof(TException).Name} to be thrown but {caught.GetType().Name} was thrown", because);
        }

        return assertion;
    }

    /// <summary>
    /// Asserts that the async action does not throw the specified exception type.
    /// </summary>
    public static async Task<VolubleAssertion<Func<Task>>> NotThrowAsync<TException>(this VolubleAssertion<Func<Task>> assertion, string? because = null)
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
            VolubleScope.FailWith($"Expected no {typeof(TException).Name} to be thrown, but it was", because);

        return assertion;
    }

    /// <summary>
    /// Asserts that the async action does not throw any exception.
    /// </summary>
    public static async Task<VolubleAssertion<Func<Task>>> NotThrowAsync(this VolubleAssertion<Func<Task>> assertion, string? because = null)
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
            VolubleScope.FailWith($"Expected no exception to be thrown, but {caught.GetType().Name} was thrown: {caught.Message}", because);

        return assertion;
    }

    /// <summary>
    /// Asserts that the async action completes within the specified timeout.
    /// </summary>
    public static async Task<VolubleAssertion<Func<Task>>> CompleteWithin(this VolubleAssertion<Func<Task>> assertion, TimeSpan timeout, string? because = null)
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
            VolubleScope.FailWith($"Expected task to complete within {timeout} but it did not", because);
        }
        else
        {
            // Cancel the delay task since the main task completed
            await cts.CancelAsync();
            // Await the task to propagate any exceptions
            await task;
        }

        return assertion;
    }

    /// <summary>
    /// Asserts that the async action throws the specified exception type and returns the exception.
    /// </summary>
    public static async Task<TException> ThrowAsyncAndReturn<TException>(this VolubleAssertion<Func<Task>> assertion, string? because = null)
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
                VolubleScope.FailWith($"Expected {typeof(TException).Name} to be thrown but no exception was thrown", because);
            else
                VolubleScope.FailWith($"Expected {typeof(TException).Name} to be thrown but {caught.GetType().Name} was thrown", because);

            throw new InvalidOperationException("Unreachable");
        }

        return typedException;
    }
}
