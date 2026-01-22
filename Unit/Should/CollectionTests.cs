using Voluble.Exceptions;

namespace Voluble.Unit.Should;

public class CollectionTests
{
    #region Contain

    [Fact]
    public void Contain_WhenCollectionContainsItem_ShouldNotThrow()
    {
        var list = new List<int> { 1, 2, 3 };
        var act = () => list.Contain(2);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void Contain_WhenCollectionDoesNotContainItem_ShouldThrow()
    {
        var list = new List<int> { 1, 2, 3 };
        var act = () => list.Contain(5);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void Contain_WithStrings_ShouldWork()
    {
        var list = new List<string> { "apple", "banana", "cherry" };
        var act = () => list.Contain("banana");

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region NotContain

    [Fact]
    public void NotContain_WhenCollectionDoesNotContainItem_ShouldNotThrow()
    {
        var list = new List<int> { 1, 2, 3 };
        var act = () => list.NotContain(5);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotContain_WhenCollectionContainsItem_ShouldThrow()
    {
        var list = new List<int> { 1, 2, 3 };
        var act = () => list.NotContain(2);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region ContainSingle

    [Fact]
    public void ContainSingle_WhenCollectionHasOneElement_ShouldNotThrow()
    {
        var list = new List<int> { 42 };
        var act = () => list.ContainSingle();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void ContainSingle_WhenCollectionIsEmpty_ShouldThrow()
    {
        var list = new List<int>();
        var act = () => list.ContainSingle();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void ContainSingle_WhenCollectionHasMultipleElements_ShouldThrow()
    {
        var list = new List<int> { 1, 2, 3 };
        var act = () => list.ContainSingle();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void ContainSingle_WithPredicate_WhenOneMatches_ShouldNotThrow()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var act = () => list.ContainSingle(x => x == 3);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void ContainSingle_WithPredicate_WhenNoneMatch_ShouldThrow()
    {
        var list = new List<int> { 1, 2, 3 };
        var act = () => list.ContainSingle(x => x > 10);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void ContainSingle_WithPredicate_WhenMultipleMatch_ShouldThrow()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var act = () => list.ContainSingle(x => x > 2);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region AllSatisfy

    [Fact]
    public void AllSatisfy_WhenAllElementsMatch_ShouldNotThrow()
    {
        var list = new List<int> { 2, 4, 6, 8 };
        var act = () => list.AllSatisfy(x => x % 2 == 0);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void AllSatisfy_WhenSomeElementsDontMatch_ShouldThrow()
    {
        var list = new List<int> { 2, 4, 5, 8 };
        var act = () => list.AllSatisfy(x => x % 2 == 0);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void AllSatisfy_WhenCollectionIsEmpty_ShouldNotThrow()
    {
        var list = new List<int>();
        var act = () => list.AllSatisfy(x => x > 100);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region AnySatisfy

    [Fact]
    public void AnySatisfy_WhenAtLeastOneMatches_ShouldNotThrow()
    {
        var list = new List<int> { 1, 2, 3, 4 };
        var act = () => list.AnySatisfy(x => x > 3);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void AnySatisfy_WhenNoneMatch_ShouldThrow()
    {
        var list = new List<int> { 1, 2, 3 };
        var act = () => list.AnySatisfy(x => x > 10);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region NoneSatisfy

    [Fact]
    public void NoneSatisfy_WhenNoElementsMatch_ShouldNotThrow()
    {
        var list = new List<int> { 1, 2, 3 };
        var act = () => list.NoneSatisfy(x => x > 10);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NoneSatisfy_WhenSomeMatch_ShouldThrow()
    {
        var list = new List<int> { 1, 2, 3, 15 };
        var act = () => list.NoneSatisfy(x => x > 10);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region BeInAscendingOrder

    [Fact]
    public void BeInAscendingOrder_WhenSorted_ShouldNotThrow()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var act = () => list.BeInAscendingOrder();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeInAscendingOrder_WhenNotSorted_ShouldThrow()
    {
        var list = new List<int> { 1, 3, 2, 4 };
        var act = () => list.BeInAscendingOrder();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeInAscendingOrder_WithEqualElements_ShouldNotThrow()
    {
        var list = new List<int> { 1, 2, 2, 3 };
        var act = () => list.BeInAscendingOrder();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeInAscendingOrder_WhenEmpty_ShouldNotThrow()
    {
        var list = new List<int>();
        var act = () => list.BeInAscendingOrder();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeInAscendingOrder_WithStrings_ShouldWork()
    {
        var list = new List<string> { "apple", "banana", "cherry" };
        var act = () => list.BeInAscendingOrder();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region BeInDescendingOrder

    [Fact]
    public void BeInDescendingOrder_WhenSorted_ShouldNotThrow()
    {
        var list = new List<int> { 5, 4, 3, 2, 1 };
        var act = () => list.BeInDescendingOrder();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeInDescendingOrder_WhenNotSorted_ShouldThrow()
    {
        var list = new List<int> { 5, 3, 4, 1 };
        var act = () => list.BeInDescendingOrder();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeInDescendingOrder_WithEqualElements_ShouldNotThrow()
    {
        var list = new List<int> { 3, 2, 2, 1 };
        var act = () => list.BeInDescendingOrder();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region HaveDistinctElements

    [Fact]
    public void HaveDistinctElements_WhenAllUnique_ShouldNotThrow()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var act = () => list.HaveDistinctElements();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void HaveDistinctElements_WhenHasDuplicates_ShouldThrow()
    {
        var list = new List<int> { 1, 2, 2, 3 };
        var act = () => list.HaveDistinctElements();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void HaveDistinctElements_WhenEmpty_ShouldNotThrow()
    {
        var list = new List<int>();
        var act = () => list.HaveDistinctElements();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region BeSubsetOf

    [Fact]
    public void BeSubsetOf_WhenAllElementsInSuperset_ShouldNotThrow()
    {
        var subset = new List<int> { 1, 2, 3 };
        var superset = new List<int> { 1, 2, 3, 4, 5 };
        var act = () => subset.BeSubsetOf(superset);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeSubsetOf_WhenSomeElementsNotInSuperset_ShouldThrow()
    {
        var subset = new List<int> { 1, 2, 6 };
        var superset = new List<int> { 1, 2, 3, 4, 5 };
        var act = () => subset.BeSubsetOf(superset);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeSubsetOf_WhenEmpty_ShouldNotThrow()
    {
        var subset = new List<int>();
        var superset = new List<int> { 1, 2, 3 };
        var act = () => subset.BeSubsetOf(superset);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region BeEquivalentTo

    [Fact]
    public void BeEquivalentTo_WhenSameElementsDifferentOrder_ShouldNotThrow()
    {
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 3, 1, 2 };
        var act = () => list1.BeEquivalentTo(list2);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeEquivalentTo_WhenSameElementsSameOrder_ShouldNotThrow()
    {
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 1, 2, 3 };
        var act = () => list1.BeEquivalentTo(list2);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeEquivalentTo_WhenDifferentElements_ShouldThrow()
    {
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 1, 2, 4 };
        var act = () => list1.BeEquivalentTo(list2);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeEquivalentTo_WhenDifferentCounts_ShouldThrow()
    {
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 1, 2 };
        var act = () => list1.BeEquivalentTo(list2);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeEquivalentTo_WhenBothEmpty_ShouldNotThrow()
    {
        var list1 = new List<int>();
        var list2 = new List<int>();
        var act = () => list1.BeEquivalentTo(list2);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region ContainAll

    [Fact]
    public void ContainAll_WhenAllItemsPresent_ShouldNotThrow()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var act = () => list.ContainAll(1, 3, 5);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void ContainAll_WhenSomeMissing_ShouldThrow()
    {
        var list = new List<int> { 1, 2, 3 };
        var act = () => list.ContainAll(1, 2, 5);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region ContainAny

    [Fact]
    public void ContainAny_WhenAtLeastOnePresent_ShouldNotThrow()
    {
        var list = new List<int> { 1, 2, 3 };
        var act = () => list.ContainAny(5, 6, 2);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void ContainAny_WhenNonePresent_ShouldThrow()
    {
        var list = new List<int> { 1, 2, 3 };
        var act = () => list.ContainAny(5, 6, 7);

        Assert.Throws<Failure>(act);
    }

    #endregion
}
