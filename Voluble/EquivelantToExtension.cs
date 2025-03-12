using System.Diagnostics;

namespace Voluble;

public static class EquivalentToExtension
{
    /**
     * Checks if result has same fields and values as expected
     */
    public static void BeEquivalentTo<TObject>(this VolubleAsserrtion<TObject?> actual, object? expected)
    {
        // todo: add code to handle arrays
        // 0. check for nulls
        if (expected == null && actual.Obj == null)
            return;
        
        if ((expected == null && actual.Obj != null) || (expected != null && actual.Obj == null))
        {
            VolubleScope.FailWith("one is null...");
            return;
        }

        // 0.1 need to check if these already are primitive...
        if ((expected.GetType().IsPrimitive || expected is decimal || expected is string) && actual.Obj != null && (actual.Obj.GetType().IsPrimitive || actual.Obj is decimal || actual.Obj is string ))
        {
            expected.Should().Be(actual.Obj);
            return;
        }
        
        Debug.Assert(expected is not null);
        Debug.Assert(actual.Obj is not null);
        
        // 1. create keyed map of expected
        var expectedProperties = expected.GetPropertyValueMap();
        var actualProperties = actual.Obj.GetPropertyValueMap();
        
        // 2. Check all properties
        foreach (var expectedProp in expectedProperties)
        {
            // check if exists
            if (!actualProperties.TryGetValue(expectedProp.Key, out var actualValue))
                VolubleScope.FailWith($"Missing Property {expectedProp.Key}");
            
            // if primitive type - do simple assertion
            if (actualValue != null && actualValue.GetType().IsPrimitive)
                actualValue.Should().Be(expectedProp.Value); // should this be inside VolubleScope?
            
            // value is not primite - do recursive check - todo: avoid infinite loop
            actualValue.Should().BeEquivalentTo(expectedProp.Value); // should this be inside VolubleScope?
        }
    }

    private static Dictionary<string, object?> GetPropertyValueMap(this object obj)
    {
        return obj.GetType()
            .GetProperties()
            .ToDictionary(property => property.Name, property => property
                .GetValue(obj)
            );
    }
}