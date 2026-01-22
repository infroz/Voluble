using Voluble.Exceptions;

namespace Voluble.Unit.Should;

public class NumericTests
{
    #region BePositive

    [Fact]
    public void BePositive_WhenPositive_ShouldNotThrow()
    {
        var act = () => 5.BePositive();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BePositive_WhenZero_ShouldThrow()
    {
        var act = () => 0.BePositive();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BePositive_WhenNegative_ShouldThrow()
    {
        var act = () => (-5).BePositive();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BePositive_WithDouble_ShouldWork()
    {
        var act = () => 0.001.BePositive();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BePositive_WithDecimal_ShouldWork()
    {
        var act = () => 0.01m.BePositive();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region BeNegative

    [Fact]
    public void BeNegative_WhenNegative_ShouldNotThrow()
    {
        var act = () => (-5).BeNegative();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeNegative_WhenZero_ShouldThrow()
    {
        var act = () => 0.BeNegative();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeNegative_WhenPositive_ShouldThrow()
    {
        var act = () => 5.BeNegative();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeNegative_WithDouble_ShouldWork()
    {
        var act = () => (-0.001).BeNegative();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region BeZero

    [Fact]
    public void BeZero_WhenZero_ShouldNotThrow()
    {
        var act = () => 0.BeZero();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeZero_WhenPositive_ShouldThrow()
    {
        var act = () => 1.BeZero();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeZero_WhenNegative_ShouldThrow()
    {
        var act = () => (-1).BeZero();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeZero_WithDouble_ShouldWork()
    {
        var act = () => 0.0.BeZero();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeZero_WithDecimal_ShouldWork()
    {
        var act = () => 0.0m.BeZero();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region NotBeZero

    [Fact]
    public void NotBeZero_WhenPositive_ShouldNotThrow()
    {
        var act = () => 5.NotBeZero();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotBeZero_WhenNegative_ShouldNotThrow()
    {
        var act = () => (-5).NotBeZero();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotBeZero_WhenZero_ShouldThrow()
    {
        var act = () => 0.NotBeZero();

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region BeInRange

    [Fact]
    public void BeInRange_WhenInRange_ShouldNotThrow()
    {
        var act = () => 5.BeInRange(1, 10);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeInRange_WhenAtMin_ShouldNotThrow()
    {
        var act = () => 1.BeInRange(1, 10);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeInRange_WhenAtMax_ShouldNotThrow()
    {
        var act = () => 10.BeInRange(1, 10);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeInRange_WhenBelowMin_ShouldThrow()
    {
        var act = () => 0.BeInRange(1, 10);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeInRange_WhenAboveMax_ShouldThrow()
    {
        var act = () => 11.BeInRange(1, 10);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeInRange_WithDoubles_ShouldWork()
    {
        var act = () => 5.5.BeInRange(1.0, 10.0);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region NotBeInRange

    [Fact]
    public void NotBeInRange_WhenBelowMin_ShouldNotThrow()
    {
        var act = () => 0.NotBeInRange(1, 10);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotBeInRange_WhenAboveMax_ShouldNotThrow()
    {
        var act = () => 11.NotBeInRange(1, 10);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotBeInRange_WhenInRange_ShouldThrow()
    {
        var act = () => 5.NotBeInRange(1, 10);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void NotBeInRange_WhenAtMin_ShouldThrow()
    {
        var act = () => 1.NotBeInRange(1, 10);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void NotBeInRange_WhenAtMax_ShouldThrow()
    {
        var act = () => 10.NotBeInRange(1, 10);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region BeApproximately (double)

    [Fact]
    public void BeApproximately_Double_WhenWithinTolerance_ShouldNotThrow()
    {
        var act = () => 1.001.BeApproximately(1.0, 0.01);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeApproximately_Double_WhenExact_ShouldNotThrow()
    {
        var act = () => 1.0.BeApproximately(1.0, 0.001);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeApproximately_Double_WhenOutsideTolerance_ShouldThrow()
    {
        var act = () => 1.1.BeApproximately(1.0, 0.01);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeApproximately_Double_WhenBothNaN_ShouldNotThrow()
    {
        var act = () => double.NaN.BeApproximately(double.NaN, 0.01);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeApproximately_Double_WhenOnlyActualIsNaN_ShouldThrow()
    {
        var act = () => double.NaN.BeApproximately(1.0, 0.01);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeApproximately_Double_WhenOnlyExpectedIsNaN_ShouldThrow()
    {
        var act = () => 1.0.BeApproximately(double.NaN, 0.01);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region BeApproximately (float)

    [Fact]
    public void BeApproximately_Float_WhenWithinTolerance_ShouldNotThrow()
    {
        var act = () => 1.001f.BeApproximately(1.0f, 0.01f);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeApproximately_Float_WhenOutsideTolerance_ShouldThrow()
    {
        var act = () => 1.1f.BeApproximately(1.0f, 0.01f);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region BeApproximately (decimal)

    [Fact]
    public void BeApproximately_Decimal_WhenWithinTolerance_ShouldNotThrow()
    {
        var act = () => 1.001m.BeApproximately(1.0m, 0.01m);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeApproximately_Decimal_WhenOutsideTolerance_ShouldThrow()
    {
        var act = () => 1.1m.BeApproximately(1.0m, 0.01m);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region Existing Comparison Tests

    [Fact]
    public void BeGreaterThan_WhenGreater_ShouldNotThrow()
    {
        var act = () => 5.BeGreaterThan(3);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeGreaterThan_WhenEqual_ShouldThrow()
    {
        var act = () => 5.BeGreaterThan(5);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeGreaterThan_WhenLess_ShouldThrow()
    {
        var act = () => 3.BeGreaterThan(5);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeLessThan_WhenLess_ShouldNotThrow()
    {
        var act = () => 3.BeLessThan(5);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeLessThan_WhenEqual_ShouldThrow()
    {
        var act = () => 5.BeLessThan(5);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeLessThan_WhenGreater_ShouldThrow()
    {
        var act = () => 5.BeLessThan(3);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeGreaterThanOrEqualTo_WhenGreater_ShouldNotThrow()
    {
        var act = () => 5.BeGreaterThanOrEqualTo(3);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeGreaterThanOrEqualTo_WhenEqual_ShouldNotThrow()
    {
        var act = () => 5.BeGreaterThanOrEqualTo(5);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeGreaterThanOrEqualTo_WhenLess_ShouldThrow()
    {
        var act = () => 3.BeGreaterThanOrEqualTo(5);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeLessThanOrEqualTo_WhenLess_ShouldNotThrow()
    {
        var act = () => 3.BeLessThanOrEqualTo(5);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeLessThanOrEqualTo_WhenEqual_ShouldNotThrow()
    {
        var act = () => 5.BeLessThanOrEqualTo(5);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeLessThanOrEqualTo_WhenGreater_ShouldThrow()
    {
        var act = () => 5.BeLessThanOrEqualTo(3);

        Assert.Throws<Failure>(act);
    }

    #endregion
}
