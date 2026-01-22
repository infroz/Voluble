using Voluble.Exceptions;

namespace Voluble.Unit.Should;

public class DateTimeTests
{
    private static readonly DateTime TestDate = new(2024, 6, 15, 14, 30, 45);

    #region BeAfter

    [Fact]
    public void BeAfter_WhenAfter_ShouldNotThrow()
    {
        var later = TestDate.AddDays(1);
        var act = () => later.BeAfter(TestDate);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeAfter_WhenEqual_ShouldThrow()
    {
        var act = () => TestDate.BeAfter(TestDate);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeAfter_WhenBefore_ShouldThrow()
    {
        var earlier = TestDate.AddDays(-1);
        var act = () => earlier.BeAfter(TestDate);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region BeBefore

    [Fact]
    public void BeBefore_WhenBefore_ShouldNotThrow()
    {
        var earlier = TestDate.AddDays(-1);
        var act = () => earlier.BeBefore(TestDate);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeBefore_WhenEqual_ShouldThrow()
    {
        var act = () => TestDate.BeBefore(TestDate);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeBefore_WhenAfter_ShouldThrow()
    {
        var later = TestDate.AddDays(1);
        var act = () => later.BeBefore(TestDate);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region BeOnOrAfter

    [Fact]
    public void BeOnOrAfter_WhenAfter_ShouldNotThrow()
    {
        var later = TestDate.AddDays(1);
        var act = () => later.BeOnOrAfter(TestDate);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeOnOrAfter_WhenEqual_ShouldNotThrow()
    {
        var act = () => TestDate.BeOnOrAfter(TestDate);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeOnOrAfter_WhenBefore_ShouldThrow()
    {
        var earlier = TestDate.AddDays(-1);
        var act = () => earlier.BeOnOrAfter(TestDate);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region BeOnOrBefore

    [Fact]
    public void BeOnOrBefore_WhenBefore_ShouldNotThrow()
    {
        var earlier = TestDate.AddDays(-1);
        var act = () => earlier.BeOnOrBefore(TestDate);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeOnOrBefore_WhenEqual_ShouldNotThrow()
    {
        var act = () => TestDate.BeOnOrBefore(TestDate);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeOnOrBefore_WhenAfter_ShouldThrow()
    {
        var later = TestDate.AddDays(1);
        var act = () => later.BeOnOrBefore(TestDate);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region BeCloseTo

    [Fact]
    public void BeCloseTo_WhenWithinTolerance_ShouldNotThrow()
    {
        var closeDate = TestDate.AddMinutes(5);
        var act = () => closeDate.BeCloseTo(TestDate, TimeSpan.FromMinutes(10));

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeCloseTo_WhenExact_ShouldNotThrow()
    {
        var act = () => TestDate.BeCloseTo(TestDate, TimeSpan.FromSeconds(1));

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeCloseTo_WhenOutsideTolerance_ShouldThrow()
    {
        var farDate = TestDate.AddHours(1);
        var act = () => farDate.BeCloseTo(TestDate, TimeSpan.FromMinutes(10));

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeCloseTo_WhenBeforeWithinTolerance_ShouldNotThrow()
    {
        var closeDate = TestDate.AddMinutes(-5);
        var act = () => closeDate.BeCloseTo(TestDate, TimeSpan.FromMinutes(10));

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region HaveYear

    [Fact]
    public void HaveYear_WhenMatches_ShouldNotThrow()
    {
        var act = () => TestDate.HaveYear(2024);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void HaveYear_WhenDoesNotMatch_ShouldThrow()
    {
        var act = () => TestDate.HaveYear(2023);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region HaveMonth

    [Fact]
    public void HaveMonth_WhenMatches_ShouldNotThrow()
    {
        var act = () => TestDate.HaveMonth(6);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void HaveMonth_WhenDoesNotMatch_ShouldThrow()
    {
        var act = () => TestDate.HaveMonth(7);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region HaveDay

    [Fact]
    public void HaveDay_WhenMatches_ShouldNotThrow()
    {
        var act = () => TestDate.HaveDay(15);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void HaveDay_WhenDoesNotMatch_ShouldThrow()
    {
        var act = () => TestDate.HaveDay(20);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region HaveHour

    [Fact]
    public void HaveHour_WhenMatches_ShouldNotThrow()
    {
        var act = () => TestDate.HaveHour(14);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void HaveHour_WhenDoesNotMatch_ShouldThrow()
    {
        var act = () => TestDate.HaveHour(10);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region HaveMinute

    [Fact]
    public void HaveMinute_WhenMatches_ShouldNotThrow()
    {
        var act = () => TestDate.HaveMinute(30);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void HaveMinute_WhenDoesNotMatch_ShouldThrow()
    {
        var act = () => TestDate.HaveMinute(45);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region HaveSecond

    [Fact]
    public void HaveSecond_WhenMatches_ShouldNotThrow()
    {
        var act = () => TestDate.HaveSecond(45);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void HaveSecond_WhenDoesNotMatch_ShouldThrow()
    {
        var act = () => TestDate.HaveSecond(30);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region HaveDate

    [Fact]
    public void HaveDate_WhenMatches_ShouldNotThrow()
    {
        var act = () => TestDate.HaveDate(2024, 6, 15);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void HaveDate_WhenDoesNotMatch_ShouldThrow()
    {
        var act = () => TestDate.HaveDate(2024, 6, 20);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region HaveTime

    [Fact]
    public void HaveTime_WhenMatches_ShouldNotThrow()
    {
        var act = () => TestDate.HaveTime(14, 30, 45);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void HaveTime_WhenDoesNotMatch_ShouldThrow()
    {
        var act = () => TestDate.HaveTime(14, 30, 00);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void HaveTime_WithoutSeconds_WhenMatches_ShouldNotThrow()
    {
        var dateWithZeroSeconds = new DateTime(2024, 6, 15, 14, 30, 0);
        var act = () => dateWithZeroSeconds.HaveTime(14, 30);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region BeOnDayOfWeek

    [Fact]
    public void BeOnDayOfWeek_WhenMatches_ShouldNotThrow()
    {
        // June 15, 2024 is a Saturday
        var act = () => TestDate.BeOnDayOfWeek(DayOfWeek.Saturday);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeOnDayOfWeek_WhenDoesNotMatch_ShouldThrow()
    {
        var act = () => TestDate.BeOnDayOfWeek(DayOfWeek.Monday);

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region BeOnWeekend

    [Fact]
    public void BeOnWeekend_WhenSaturday_ShouldNotThrow()
    {
        // June 15, 2024 is a Saturday
        var act = () => TestDate.BeOnWeekend();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeOnWeekend_WhenSunday_ShouldNotThrow()
    {
        var sunday = new DateTime(2024, 6, 16); // Sunday
        var act = () => sunday.BeOnWeekend();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeOnWeekend_WhenWeekday_ShouldThrow()
    {
        var monday = new DateTime(2024, 6, 17); // Monday
        var act = () => monday.BeOnWeekend();

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region BeOnWeekday

    [Fact]
    public void BeOnWeekday_WhenWeekday_ShouldNotThrow()
    {
        var monday = new DateTime(2024, 6, 17); // Monday
        var act = () => monday.BeOnWeekday();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeOnWeekday_WhenWeekend_ShouldThrow()
    {
        // June 15, 2024 is a Saturday
        var act = () => TestDate.BeOnWeekday();

        Assert.Throws<Failure>(act);
    }

    #endregion

    #region DateTimeOffset Assertions

    [Fact]
    public void DateTimeOffset_BeAfter_WhenAfter_ShouldNotThrow()
    {
        var date = new DateTimeOffset(2024, 6, 15, 14, 30, 0, TimeSpan.Zero);
        var earlier = date.AddDays(-1);
        var act = () => date.BeAfter(earlier);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void DateTimeOffset_BeAfter_WhenBefore_ShouldThrow()
    {
        var date = new DateTimeOffset(2024, 6, 15, 14, 30, 0, TimeSpan.Zero);
        var later = date.AddDays(1);
        var act = () => date.BeAfter(later);

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void DateTimeOffset_BeBefore_WhenBefore_ShouldNotThrow()
    {
        var date = new DateTimeOffset(2024, 6, 15, 14, 30, 0, TimeSpan.Zero);
        var later = date.AddDays(1);
        var act = () => date.BeBefore(later);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void DateTimeOffset_BeOnOrAfter_WhenEqual_ShouldNotThrow()
    {
        var date = new DateTimeOffset(2024, 6, 15, 14, 30, 0, TimeSpan.Zero);
        var act = () => date.BeOnOrAfter(date);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void DateTimeOffset_BeOnOrBefore_WhenEqual_ShouldNotThrow()
    {
        var date = new DateTimeOffset(2024, 6, 15, 14, 30, 0, TimeSpan.Zero);
        var act = () => date.BeOnOrBefore(date);

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void DateTimeOffset_BeCloseTo_WhenWithinTolerance_ShouldNotThrow()
    {
        var date = new DateTimeOffset(2024, 6, 15, 14, 30, 0, TimeSpan.Zero);
        var close = date.AddMinutes(5);
        var act = () => close.BeCloseTo(date, TimeSpan.FromMinutes(10));

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void DateTimeOffset_BeCloseTo_WhenOutsideTolerance_ShouldThrow()
    {
        var date = new DateTimeOffset(2024, 6, 15, 14, 30, 0, TimeSpan.Zero);
        var far = date.AddHours(1);
        var act = () => far.BeCloseTo(date, TimeSpan.FromMinutes(10));

        Assert.Throws<Failure>(act);
    }

    #endregion
}
