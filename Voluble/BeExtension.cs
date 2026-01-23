namespace Voluble;

/**
 * BeExtension is a class that contains extension methods for the ShouldExtension class.
 */
public static class BeExtension
{
   // Simple Comparisons
   public static VolubleAssertion<TEquatable> Be<TEquatable>(this VolubleAssertion<TEquatable> assertion, TEquatable? expected, string? because = null)
   {
      if (assertion.Obj is null && expected is not null)
         VolubleScope.FailWith($"Expected {assertion.Name} to be {expected}", because);

      if (assertion.Obj is not null && !assertion.Obj.Equals(expected))
         VolubleScope.FailWith($"Expected {assertion.Obj} ({assertion.Name}) to be {expected}", because);

      return assertion;
   }
}