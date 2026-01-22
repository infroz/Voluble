using Voluble.Exceptions;

namespace Voluble.Unit.Should;

public class DictionaryTests
{
    private static Dictionary<string, int> CreateTestDictionary() => new()
    {
        ["one"] = 1,
        ["two"] = 2,
        ["three"] = 3
    };

    #region ContainKey

    [Fact]
    public void ContainKey_WhenKeyExists_ShouldNotThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.ContainKey("two");

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void ContainKey_WhenKeyDoesNotExist_ShouldThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.ContainKey("four");

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region NotContainKey

    [Fact]
    public void NotContainKey_WhenKeyDoesNotExist_ShouldNotThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.NotContainKey("four");

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotContainKey_WhenKeyExists_ShouldThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.NotContainKey("two");

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region ContainKeys

    [Fact]
    public void ContainKeys_WhenAllKeysExist_ShouldNotThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.ContainKeys("one", "two");

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void ContainKeys_WhenSomeKeysMissing_ShouldThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.ContainKeys("one", "four");

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void ContainKeys_WhenAllKeysMissing_ShouldThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.ContainKeys("four", "five");

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region ContainValue

    [Fact]
    public void ContainValue_WhenValueExists_ShouldNotThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.ContainValue(2);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void ContainValue_WhenValueDoesNotExist_ShouldThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.ContainValue(5);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region NotContainValue

    [Fact]
    public void NotContainValue_WhenValueDoesNotExist_ShouldNotThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.NotContainValue(5);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotContainValue_WhenValueExists_ShouldThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.NotContainValue(2);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region ContainEntry

    [Fact]
    public void ContainEntry_WhenEntryExists_ShouldNotThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.ContainEntry("two", 2);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void ContainEntry_WhenKeyDoesNotExist_ShouldThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.ContainEntry("four", 4);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void ContainEntry_WhenKeyExistsButValueDiffers_ShouldThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.ContainEntry("two", 5);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region NotContainEntry

    [Fact]
    public void NotContainEntry_WhenKeyDoesNotExist_ShouldNotThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.NotContainEntry("four", 4);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotContainEntry_WhenKeyExistsButValueDiffers_ShouldNotThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.NotContainEntry("two", 5);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotContainEntry_WhenEntryExists_ShouldThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.NotContainEntry("two", 2);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region BeEmpty

    [Fact]
    public void BeEmpty_WhenEmpty_ShouldNotThrow()
    {
        var dict = new Dictionary<string, int>();
        var act = () => dict.BeEmpty();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeEmpty_WhenNotEmpty_ShouldThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.BeEmpty();

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region NotBeEmpty

    [Fact]
    public void NotBeEmpty_WhenNotEmpty_ShouldNotThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.NotBeEmpty();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotBeEmpty_WhenEmpty_ShouldThrow()
    {
        var dict = new Dictionary<string, int>();
        var act = () => dict.NotBeEmpty();

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region HaveCount

    [Fact]
    public void HaveCount_WhenCountMatches_ShouldNotThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.HaveCount(3);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void HaveCount_WhenCountDoesNotMatch_ShouldThrow()
    {
        var dict = CreateTestDictionary();
        var act = () => dict.HaveCount(5);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void HaveCount_WhenEmptyAndExpectsZero_ShouldNotThrow()
    {
        var dict = new Dictionary<string, int>();
        var act = () => dict.HaveCount(0);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region BeEquivalentTo

    [Fact]
    public void BeEquivalentTo_WhenSame_ShouldNotThrow()
    {
        var dict1 = CreateTestDictionary();
        var dict2 = CreateTestDictionary();
        var act = () => dict1.BeEquivalentTo(dict2);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeEquivalentTo_WhenDifferentCount_ShouldThrow()
    {
        var dict1 = CreateTestDictionary();
        var dict2 = new Dictionary<string, int> { ["one"] = 1 };
        var act = () => dict1.BeEquivalentTo(dict2);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeEquivalentTo_WhenMissingKey_ShouldThrow()
    {
        var dict1 = CreateTestDictionary();
        var dict2 = new Dictionary<string, int>
        {
            ["one"] = 1,
            ["two"] = 2,
            ["four"] = 4
        };
        var act = () => dict1.BeEquivalentTo(dict2);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeEquivalentTo_WhenDifferentValue_ShouldThrow()
    {
        var dict1 = CreateTestDictionary();
        var dict2 = new Dictionary<string, int>
        {
            ["one"] = 1,
            ["two"] = 99,
            ["three"] = 3
        };
        var act = () => dict1.BeEquivalentTo(dict2);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeEquivalentTo_WhenBothEmpty_ShouldNotThrow()
    {
        var dict1 = new Dictionary<string, int>();
        var dict2 = new Dictionary<string, int>();
        var act = () => dict1.BeEquivalentTo(dict2);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region Contain (dictionary subset)

    [Fact]
    public void Contain_WhenHasAllExpectedEntries_ShouldNotThrow()
    {
        var dict = CreateTestDictionary();
        var expected = new Dictionary<string, int>
        {
            ["one"] = 1,
            ["two"] = 2
        };
        var act = () => dict.Contain(expected);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void Contain_WhenMissingExpectedKey_ShouldThrow()
    {
        var dict = CreateTestDictionary();
        var expected = new Dictionary<string, int>
        {
            ["one"] = 1,
            ["four"] = 4
        };
        var act = () => dict.Contain(expected);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void Contain_WhenValueDiffers_ShouldThrow()
    {
        var dict = CreateTestDictionary();
        var expected = new Dictionary<string, int>
        {
            ["one"] = 1,
            ["two"] = 99
        };
        var act = () => dict.Contain(expected);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void Contain_WhenExpectedIsEmpty_ShouldNotThrow()
    {
        var dict = CreateTestDictionary();
        var expected = new Dictionary<string, int>();
        var act = () => dict.Contain(expected);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region With Different Types

    [Fact]
    public void ContainKey_WithIntKey_ShouldWork()
    {
        var dict = new Dictionary<int, string>
        {
            [1] = "one",
            [2] = "two"
        };
        var act = () => dict.ContainKey(1);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void ContainValue_WithObjectValue_ShouldWork()
    {
        var dict = new Dictionary<string, object>
        {
            ["key1"] = "value1",
            ["key2"] = 42
        };
        var act = () => dict.ContainValue(42);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion
}
