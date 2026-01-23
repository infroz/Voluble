namespace Voluble;

/// <summary>
/// Extension methods for DateTime assertions.
/// </summary>
public static class DateTimeExtension
{
    #region Comparison Assertions

    /// <summary>
    /// Asserts that the datetime is after the specified datetime.
    /// </summary>
    public static void BeAfter(this DateTime value, DateTime other, string? because = null)
    {
        if (value <= other)
            VolubleScope.FailWith($"Expected {value:O} to be after {other:O}", because);
    }

    /// <summary>
    /// Asserts that the datetime is before the specified datetime.
    /// </summary>
    public static void BeBefore(this DateTime value, DateTime other, string? because = null)
    {
        if (value >= other)
            VolubleScope.FailWith($"Expected {value:O} to be before {other:O}", because);
    }

    /// <summary>
    /// Asserts that the datetime is on or after the specified datetime.
    /// </summary>
    public static void BeOnOrAfter(this DateTime value, DateTime other, string? because = null)
    {
        if (value < other)
            VolubleScope.FailWith($"Expected {value:O} to be on or after {other:O}", because);
    }

    /// <summary>
    /// Asserts that the datetime is on or before the specified datetime.
    /// </summary>
    public static void BeOnOrBefore(this DateTime value, DateTime other, string? because = null)
    {
        if (value > other)
            VolubleScope.FailWith($"Expected {value:O} to be on or before {other:O}", because);
    }

    /// <summary>
    /// Asserts that the datetime is close to the expected datetime within the specified tolerance.
    /// </summary>
    public static void BeCloseTo(this DateTime value, DateTime expected, TimeSpan tolerance, string? because = null)
    {
        var difference = (value - expected).Duration();
        if (difference > tolerance)
            VolubleScope.FailWith($"Expected {value:O} to be close to {expected:O} (±{tolerance}) but difference was {difference}", because);
    }

    #endregion

    #region Component Assertions

    /// <summary>
    /// Asserts that the datetime has the specified year.
    /// </summary>
    public static void HaveYear(this DateTime value, int year, string? because = null)
    {
        if (value.Year != year)
            VolubleScope.FailWith($"Expected {value:O} to have year {year} but was {value.Year}", because);
    }

    /// <summary>
    /// Asserts that the datetime has the specified month.
    /// </summary>
    public static void HaveMonth(this DateTime value, int month, string? because = null)
    {
        if (value.Month != month)
            VolubleScope.FailWith($"Expected {value:O} to have month {month} but was {value.Month}", because);
    }

    /// <summary>
    /// Asserts that the datetime has the specified day.
    /// </summary>
    public static void HaveDay(this DateTime value, int day, string? because = null)
    {
        if (value.Day != day)
            VolubleScope.FailWith($"Expected {value:O} to have day {day} but was {value.Day}", because);
    }

    /// <summary>
    /// Asserts that the datetime has the specified hour.
    /// </summary>
    public static void HaveHour(this DateTime value, int hour, string? because = null)
    {
        if (value.Hour != hour)
            VolubleScope.FailWith($"Expected {value:O} to have hour {hour} but was {value.Hour}", because);
    }

    /// <summary>
    /// Asserts that the datetime has the specified minute.
    /// </summary>
    public static void HaveMinute(this DateTime value, int minute, string? because = null)
    {
        if (value.Minute != minute)
            VolubleScope.FailWith($"Expected {value:O} to have minute {minute} but was {value.Minute}", because);
    }

    /// <summary>
    /// Asserts that the datetime has the specified second.
    /// </summary>
    public static void HaveSecond(this DateTime value, int second, string? because = null)
    {
        if (value.Second != second)
            VolubleScope.FailWith($"Expected {value:O} to have second {second} but was {value.Second}", because);
    }

    /// <summary>
    /// Asserts that the datetime has the specified date (ignoring time).
    /// </summary>
    public static void HaveDate(this DateTime value, int year, int month, int day, string? because = null)
    {
        if (value.Year != year || value.Month != month || value.Day != day)
            VolubleScope.FailWith($"Expected {value:O} to have date {year}-{month:D2}-{day:D2} but was {value:yyyy-MM-dd}", because);
    }

    /// <summary>
    /// Asserts that the datetime has the specified time (ignoring date).
    /// </summary>
    public static void HaveTime(this DateTime value, int hour, int minute, int second = 0, string? because = null)
    {
        if (value.Hour != hour || value.Minute != minute || value.Second != second)
            VolubleScope.FailWith($"Expected {value:O} to have time {hour:D2}:{minute:D2}:{second:D2} but was {value:HH:mm:ss}", because);
    }

    #endregion

    #region Day of Week Assertions

    /// <summary>
    /// Asserts that the datetime is on the specified day of week.
    /// </summary>
    public static void BeOnDayOfWeek(this DateTime value, DayOfWeek dayOfWeek, string? because = null)
    {
        if (value.DayOfWeek != dayOfWeek)
            VolubleScope.FailWith($"Expected {value:O} to be on {dayOfWeek} but was {value.DayOfWeek}", because);
    }

    /// <summary>
    /// Asserts that the datetime is on a weekend (Saturday or Sunday).
    /// </summary>
    public static void BeOnWeekend(this DateTime value, string? because = null)
    {
        if (value.DayOfWeek != DayOfWeek.Saturday && value.DayOfWeek != DayOfWeek.Sunday)
            VolubleScope.FailWith($"Expected {value:O} to be on weekend but was {value.DayOfWeek}", because);
    }

    /// <summary>
    /// Asserts that the datetime is on a weekday (Monday through Friday).
    /// </summary>
    public static void BeOnWeekday(this DateTime value, string? because = null)
    {
        if (value.DayOfWeek == DayOfWeek.Saturday || value.DayOfWeek == DayOfWeek.Sunday)
            VolubleScope.FailWith($"Expected {value:O} to be on weekday but was {value.DayOfWeek}", because);
    }

    #endregion

    #region DateTimeOffset Assertions

    /// <summary>
    /// Asserts that the datetimeoffset is after the specified datetimeoffset.
    /// </summary>
    public static void BeAfter(this DateTimeOffset value, DateTimeOffset other, string? because = null)
    {
        if (value <= other)
            VolubleScope.FailWith($"Expected {value:O} to be after {other:O}", because);
    }

    /// <summary>
    /// Asserts that the datetimeoffset is before the specified datetimeoffset.
    /// </summary>
    public static void BeBefore(this DateTimeOffset value, DateTimeOffset other, string? because = null)
    {
        if (value >= other)
            VolubleScope.FailWith($"Expected {value:O} to be before {other:O}", because);
    }

    /// <summary>
    /// Asserts that the datetimeoffset is on or after the specified datetimeoffset.
    /// </summary>
    public static void BeOnOrAfter(this DateTimeOffset value, DateTimeOffset other, string? because = null)
    {
        if (value < other)
            VolubleScope.FailWith($"Expected {value:O} to be on or after {other:O}", because);
    }

    /// <summary>
    /// Asserts that the datetimeoffset is on or before the specified datetimeoffset.
    /// </summary>
    public static void BeOnOrBefore(this DateTimeOffset value, DateTimeOffset other, string? because = null)
    {
        if (value > other)
            VolubleScope.FailWith($"Expected {value:O} to be on or before {other:O}", because);
    }

    /// <summary>
    /// Asserts that the datetimeoffset is close to the expected datetimeoffset within the specified tolerance.
    /// </summary>
    public static void BeCloseTo(this DateTimeOffset value, DateTimeOffset expected, TimeSpan tolerance, string? because = null)
    {
        var difference = (value - expected).Duration();
        if (difference > tolerance)
            VolubleScope.FailWith($"Expected {value:O} to be close to {expected:O} (±{tolerance}) but difference was {difference}", because);
    }

    #endregion
}
