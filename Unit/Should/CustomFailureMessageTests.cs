using Voluble.Exceptions;

namespace Voluble.Unit.Should;

/// <summary>
/// Tests for Phase 8: Custom failure messages via the 'because' parameter.
/// </summary>
[Collection("Sequential")]
public class CustomFailureMessageTests
{
    #region Be Extension

    [Fact]
    public void Be_WithBecause_IncludesReasonInFailureMessage()
    {
        var ex = Assert.Throws<Failure>(() =>
        {
            5.Should().Be(6, "the value must match the expected");
        });

        Assert.Contains("because the value must match the expected", ex.Message);
    }

    [Fact]
    public void Be_WithoutBecause_DoesNotIncludeBecause()
    {
        var ex = Assert.Throws<Failure>(() =>
        {
            5.Should().Be(6);
        });

        Assert.DoesNotContain("because", ex.Message);
    }

    #endregion

    #region NotBe Extension

    [Fact]
    public void NotBe_WithBecause_IncludesReasonInFailureMessage()
    {
        var ex = Assert.Throws<Failure>(() =>
        {
            5.Should().NotBe(5, "values should differ");
        });

        Assert.Contains("because values should differ", ex.Message);
    }

    #endregion

    #region Bool Extension

    [Fact]
    public void BeTrue_WithBecause_IncludesReasonInFailureMessage()
    {
        var ex = Assert.Throws<Failure>(() =>
        {
            false.BeTrue("the flag should be enabled");
        });

        Assert.Contains("because the flag should be enabled", ex.Message);
    }

    [Fact]
    public void BeFalse_WithBecause_IncludesReasonInFailureMessage()
    {
        var ex = Assert.Throws<Failure>(() =>
        {
            true.BeFalse("the flag should be disabled");
        });

        Assert.Contains("because the flag should be disabled", ex.Message);
    }

    #endregion

    #region String Extension

    [Fact]
    public void StringContain_WithBecause_IncludesReasonInFailureMessage()
    {
        var ex = Assert.Throws<Failure>(() =>
        {
            "hello".Should().Contain("world", "greetings should include world");
        });

        Assert.Contains("because greetings should include world", ex.Message);
    }

    [Fact]
    public void StringStartWith_WithBecause_IncludesReasonInFailureMessage()
    {
        var ex = Assert.Throws<Failure>(() =>
        {
            "hello".Should().StartWith("world", "the string should start properly");
        });

        Assert.Contains("because the string should start properly", ex.Message);
    }

    #endregion

    #region Numeric Extension

    [Fact]
    public void BeGreaterThan_WithBecause_IncludesReasonInFailureMessage()
    {
        var ex = Assert.Throws<Failure>(() =>
        {
            5.BeGreaterThan(10, "the value must exceed the threshold");
        });

        Assert.Contains("because the value must exceed the threshold", ex.Message);
    }

    [Fact]
    public void BePositive_WithBecause_IncludesReasonInFailureMessage()
    {
        var ex = Assert.Throws<Failure>(() =>
        {
            (-5).BePositive("counts cannot be negative");
        });

        Assert.Contains("because counts cannot be negative", ex.Message);
    }

    [Fact]
    public void BeInRange_WithBecause_IncludesReasonInFailureMessage()
    {
        var ex = Assert.Throws<Failure>(() =>
        {
            50.BeInRange(0, 10, "the value is out of acceptable bounds");
        });

        Assert.Contains("because the value is out of acceptable bounds", ex.Message);
    }

    #endregion

    #region Collection Extension

    [Fact]
    public void CollectionContain_WithBecause_IncludesReasonInFailureMessage()
    {
        var list = new List<int> { 1, 2, 3 };

        var ex = Assert.Throws<Failure>(() =>
        {
            list.Contain(5, "the list should include the required item");
        });

        Assert.Contains("because the list should include the required item", ex.Message);
    }

    [Fact]
    public void HaveCount_WithBecause_IncludesReasonInFailureMessage()
    {
        var list = new List<int> { 1, 2, 3 };

        var ex = Assert.Throws<Failure>(() =>
        {
            list.HaveCount(5, "the collection size is incorrect");
        });

        Assert.Contains("because the collection size is incorrect", ex.Message);
    }

    [Fact]
    public void BeEmpty_WithBecause_IncludesReasonInFailureMessage()
    {
        var list = new List<int> { 1 };

        var ex = Assert.Throws<Failure>(() =>
        {
            list.BeEmpty("the list should have been cleared");
        });

        Assert.Contains("because the list should have been cleared", ex.Message);
    }

    #endregion

    #region Dictionary Extension

    [Fact]
    public void DictionaryContainKey_WithBecause_IncludesReasonInFailureMessage()
    {
        var dict = new Dictionary<string, int> { { "a", 1 } };

        var ex = Assert.Throws<Failure>(() =>
        {
            dict.ContainKey("b", "the key is required");
        });

        Assert.Contains("because the key is required", ex.Message);
    }

    [Fact]
    public void DictionaryContainValue_WithBecause_IncludesReasonInFailureMessage()
    {
        var dict = new Dictionary<string, int> { { "a", 1 } };

        var ex = Assert.Throws<Failure>(() =>
        {
            dict.ContainValue(2, "the value should be present");
        });

        Assert.Contains("because the value should be present", ex.Message);
    }

    #endregion

    #region DateTime Extension

    [Fact]
    public void BeAfter_WithBecause_IncludesReasonInFailureMessage()
    {
        var date = new DateTime(2023, 1, 1);
        var laterDate = new DateTime(2024, 1, 1);

        var ex = Assert.Throws<Failure>(() =>
        {
            date.BeAfter(laterDate, "the date must be in the future");
        });

        Assert.Contains("because the date must be in the future", ex.Message);
    }

    [Fact]
    public void HaveYear_WithBecause_IncludesReasonInFailureMessage()
    {
        var date = new DateTime(2023, 1, 1);

        var ex = Assert.Throws<Failure>(() =>
        {
            date.HaveYear(2024, "the year is wrong");
        });

        Assert.Contains("because the year is wrong", ex.Message);
    }

    #endregion

    #region Type Extension

    [Fact]
    public void BeOfType_WithBecause_IncludesReasonInFailureMessage()
    {
        object value = "test";

        var ex = Assert.Throws<Failure>(() =>
        {
            value.Should().BeOfType<int>("the type conversion failed");
        });

        Assert.Contains("because the type conversion failed", ex.Message);
    }

    #endregion

    #region Action Extension

    [Fact]
    public void ActionThrow_WithBecause_IncludesReasonInFailureMessage()
    {
        Action act = () => { };

        var ex = Assert.Throws<Failure>(() =>
        {
            act.Should().Throw<InvalidOperationException>("the operation should fail");
        });

        Assert.Contains("because the operation should fail", ex.Message);
    }

    #endregion

    #region VolubleScope Integration

    [Fact]
    public void VolubleScope_CollectsFailuresWithBecauseMessage()
    {
        var ex = Assert.Throws<FailureCollection>(() =>
        {
            using var scope = new VolubleScope();
            5.Should().Be(6, "first check");
            10.Should().Be(20, "second check");
        });

        Assert.Contains("because first check", ex.Message);
        Assert.Contains("because second check", ex.Message);
    }

    #endregion
}
