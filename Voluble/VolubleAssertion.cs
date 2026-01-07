namespace Voluble;

public partial class VolubleAssertion<TObject>
{
    internal TObject? Obj { get; init; }
    internal string Name { get; init; } = null!;
}