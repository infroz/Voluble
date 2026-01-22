namespace Voluble;

/// <summary>
/// Extension methods for type assertions.
/// </summary>
public static class TypeExtension
{
    /// <summary>
    /// Asserts that the object is exactly the specified type (not a derived type).
    /// </summary>
    public static void BeOfType<TExpected>(this VolubleAssertion<object?> assertion)
    {
        if (assertion.Obj is null)
        {
            VolubleScope.FailWith($"Expected {assertion.Name} to be of type '{typeof(TExpected).Name}' but it was null");
            return;
        }

        var actualType = assertion.Obj.GetType();
        if (actualType != typeof(TExpected))
            VolubleScope.FailWith($"Expected {assertion.Name} to be of type '{typeof(TExpected).Name}' but was '{actualType.Name}'");
    }

    /// <summary>
    /// Asserts that the object is not the specified type.
    /// </summary>
    public static void NotBeOfType<TExpected>(this VolubleAssertion<object?> assertion)
    {
        if (assertion.Obj is null)
            return; // null is not of any type

        var actualType = assertion.Obj.GetType();
        if (actualType == typeof(TExpected))
            VolubleScope.FailWith($"Expected {assertion.Name} to not be of type '{typeof(TExpected).Name}' but it was");
    }

    /// <summary>
    /// Asserts that the object can be assigned to the specified type (includes inheritance and interfaces).
    /// </summary>
    public static void BeAssignableTo<TExpected>(this VolubleAssertion<object?> assertion)
    {
        if (assertion.Obj is null)
        {
            VolubleScope.FailWith($"Expected {assertion.Name} to be assignable to '{typeof(TExpected).Name}' but it was null");
            return;
        }

        if (assertion.Obj is not TExpected)
            VolubleScope.FailWith($"Expected {assertion.Name} to be assignable to '{typeof(TExpected).Name}' but was '{assertion.Obj.GetType().Name}'");
    }

    /// <summary>
    /// Asserts that the object cannot be assigned to the specified type.
    /// </summary>
    public static void NotBeAssignableTo<TExpected>(this VolubleAssertion<object?> assertion)
    {
        if (assertion.Obj is null)
            return; // null cannot be assigned

        if (assertion.Obj is TExpected)
            VolubleScope.FailWith($"Expected {assertion.Name} to not be assignable to '{typeof(TExpected).Name}' but it was");
    }
}
