using Voluble.Exceptions;

namespace Voluble.Unit.Should.BeEquivalentTo;

/// <summary>
/// Tests for Phase 9: Array support in BeEquivalentTo
/// </summary>
public class ArrayTests
{
    #region Primitive Arrays

    [Fact]
    public void IntArray_EquivalentToSameArray_Success()
    {
        var actual = new[] { 1, 2, 3 };
        var expected = new[] { 1, 2, 3 };

        var ex = Record.Exception(() => actual.Should().BeEquivalentTo(expected));

        Assert.Null(ex);
    }

    [Fact]
    public void IntArray_DifferentValues_Failure()
    {
        var actual = new[] { 1, 2, 3 };
        var expected = new[] { 1, 2, 4 };

        Assert.Throws<Failure>(() => actual.Should().BeEquivalentTo(expected));
    }

    [Fact]
    public void IntArray_DifferentLengths_Failure()
    {
        var actual = new[] { 1, 2, 3 };
        var expected = new[] { 1, 2 };

        var ex = Assert.Throws<Failure>(() => actual.Should().BeEquivalentTo(expected));

        Assert.Contains("length", ex.Message);
    }

    [Fact]
    public void StringArray_EquivalentToSameArray_Success()
    {
        var actual = new[] { "a", "b", "c" };
        var expected = new[] { "a", "b", "c" };

        var ex = Record.Exception(() => actual.Should().BeEquivalentTo(expected));

        Assert.Null(ex);
    }

    [Fact]
    public void StringArray_DifferentValues_Failure()
    {
        var actual = new[] { "a", "b", "c" };
        var expected = new[] { "a", "b", "d" };

        Assert.Throws<Failure>(() => actual.Should().BeEquivalentTo(expected));
    }

    [Fact]
    public void EmptyArray_EquivalentToEmptyArray_Success()
    {
        var actual = Array.Empty<int>();
        var expected = Array.Empty<int>();

        var ex = Record.Exception(() => actual.Should().BeEquivalentTo(expected));

        Assert.Null(ex);
    }

    [Fact]
    public void EmptyArray_NotEquivalentToNonEmptyArray_Failure()
    {
        var actual = Array.Empty<int>();
        var expected = new[] { 1 };

        Assert.Throws<Failure>(() => actual.Should().BeEquivalentTo(expected));
    }

    #endregion

    #region Object Arrays

    [Fact]
    public void ObjectArray_EquivalentObjects_Success()
    {
        var actual = new[]
        {
            new { Name = "Alice", Age = 30 },
            new { Name = "Bob", Age = 25 }
        };
        var expected = new[]
        {
            new { Name = "Alice", Age = 30 },
            new { Name = "Bob", Age = 25 }
        };

        var ex = Record.Exception(() => actual.Should().BeEquivalentTo(expected));

        Assert.Null(ex);
    }

    [Fact]
    public void ObjectArray_DifferentObjectValues_Failure()
    {
        var actual = new[]
        {
            new { Name = "Alice", Age = 30 },
            new { Name = "Bob", Age = 25 }
        };
        var expected = new[]
        {
            new { Name = "Alice", Age = 30 },
            new { Name = "Bob", Age = 26 }  // Different age
        };

        Assert.Throws<Failure>(() => actual.Should().BeEquivalentTo(expected));
    }

    #endregion

    #region Nested Arrays

    [Fact]
    public void NestedArray_EquivalentArrays_Success()
    {
        var actual = new[] { new[] { 1, 2 }, new[] { 3, 4 } };
        var expected = new[] { new[] { 1, 2 }, new[] { 3, 4 } };

        var ex = Record.Exception(() => actual.Should().BeEquivalentTo(expected));

        Assert.Null(ex);
    }

    [Fact]
    public void NestedArray_DifferentInnerValues_Failure()
    {
        var actual = new[] { new[] { 1, 2 }, new[] { 3, 4 } };
        var expected = new[] { new[] { 1, 2 }, new[] { 3, 5 } };  // Different value

        Assert.Throws<Failure>(() => actual.Should().BeEquivalentTo(expected));
    }

    #endregion

    #region Lists (IEnumerable support)

    [Fact]
    public void List_EquivalentToSameList_Success()
    {
        var actual = new List<int> { 1, 2, 3 };
        var expected = new List<int> { 1, 2, 3 };

        var ex = Record.Exception(() => actual.Should().BeEquivalentTo(expected));

        Assert.Null(ex);
    }

    [Fact]
    public void List_DifferentValues_Failure()
    {
        var actual = new List<int> { 1, 2, 3 };
        var expected = new List<int> { 1, 2, 4 };

        Assert.Throws<Failure>(() => actual.Should().BeEquivalentTo(expected));
    }

    [Fact]
    public void List_DifferentCounts_Failure()
    {
        var actual = new List<int> { 1, 2, 3 };
        var expected = new List<int> { 1, 2 };

        var ex = Assert.Throws<Failure>(() => actual.Should().BeEquivalentTo(expected));

        Assert.Contains("elements", ex.Message);
    }

    #endregion

    #region Objects with Array Properties

    [Fact]
    public void ObjectWithArrayProperty_EquivalentArrays_Success()
    {
        var actual = new { Numbers = new[] { 1, 2, 3 } };
        var expected = new { Numbers = new[] { 1, 2, 3 } };

        var ex = Record.Exception(() => actual.Should().BeEquivalentTo(expected));

        Assert.Null(ex);
    }

    [Fact]
    public void ObjectWithArrayProperty_DifferentArrayValues_Failure()
    {
        var actual = new { Numbers = new[] { 1, 2, 3 } };
        var expected = new { Numbers = new[] { 1, 2, 4 } };

        Assert.Throws<Failure>(() => actual.Should().BeEquivalentTo(expected));
    }

    [Fact]
    public void ObjectWithListProperty_EquivalentLists_Success()
    {
        var actual = new { Items = new List<string> { "a", "b" } };
        var expected = new { Items = new List<string> { "a", "b" } };

        var ex = Record.Exception(() => actual.Should().BeEquivalentTo(expected));

        Assert.Null(ex);
    }

    #endregion
}
