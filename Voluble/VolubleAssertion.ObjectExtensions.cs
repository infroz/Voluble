using System.Diagnostics.CodeAnalysis;

namespace Voluble;

public partial class VolubleAssertion<TObject>
{
    public void BeNull()
    {
        if (Obj is not null)
            VolubleScope.FailWith("Object is not null");
    }
    
    [MemberNotNull(nameof(Obj))]
    public void NotBeNull()
    {
        if (Obj is null)
            VolubleScope.FailWith("Object is null");
    }
}