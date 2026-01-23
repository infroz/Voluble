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

        // In VolubleScope, FailWith defers the exception rather than throwing immediately.
        // The [MemberNotNull] contract is fulfilled at scope disposal, not here.
#pragma warning disable CS8774
        return this;
#pragma warning restore CS8774
    }
}