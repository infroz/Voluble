using System.Diagnostics.CodeAnalysis;

namespace Voluble;

public partial class VolubleAssertion<TObject>
{
    public VolubleAssertion<TObject> BeNull(string? because = null)
    {
        if (Obj is not null)
            VolubleScope.FailWith($"Expected {Name} to be null but was '{Obj}'", because);
        return this;
    }

    [MemberNotNull(nameof(Obj))]
    public VolubleAssertion<TObject> NotBeNull(string? because = null)
    {
        if (Obj is null)
            VolubleScope.FailWith($"Expected {Name} to not be null", because);
        return this;
    }
}