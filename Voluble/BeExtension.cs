namespace Voluble;

/**
 * BeExtension is a class that contains extension methods for the ShouldExtension class.
 */
public static class BeExtension
{
   // Simple Comparisons
   public static void Be(this VolubleAsserrtion assertion, object expected)
   {
      if (!assertion.Obj.Equals(expected))
      {
         VolubleScope.FailWith($"Expected {assertion.Obj} ({assertion.Name}) to be {expected}");
      }
   }
}