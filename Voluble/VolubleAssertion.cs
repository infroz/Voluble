namespace Voluble;

public partial class VolubleAssertion<TObject>
{
    internal TObject? Obj { get; init; }
    internal string Name { get; init; } = null!;

    /// <summary>
    /// Returns this assertion for fluent chaining.
    /// Enables syntax like: value.Should().NotBeNull().And.BeGreaterThan(0)
    /// </summary>
    public VolubleAssertion<TObject> And => this;
}