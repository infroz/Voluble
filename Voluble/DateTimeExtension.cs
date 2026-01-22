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
    public static void BeAfter(this DateTime value, DateTime other)
    {
        if (value <= other)
            VolubleScope.FailWith($"Expected {value:O} to be after {other:O}");
    }

    /// <summary>
    /// Asserts that the datetime is before the specified datetime.
    /// </summary>
    public static void BeBefore(this DateTime value, DateTime other)
    {
        if (value >= other)
            VolubleScope.FailWith($"Expected {value:O} to be before {other:O}");
    }

    /// <summary>
    /// Asserts that the datetime is on or after the specified datetime.
    /// </summary>
    public static void BeOnOrAfter(this DateTime value, DateTime other)
    {
        if (value < other)
            VolubleScope.FailWith($"Expected {value:O} to be on or after {other:O}");
    }

    /// <summary>
    /// Asserts that the datetime is on or before the specified datetime.
    /// </summary>
    public static void BeOnOrBefore(this DateTime value, DateTime other)
    {
        if (value > other)
            VolubleScope.FailWith($"Expected {value:O} to be on or before {other:O}");
    }

    /// <summary>
    /// Asserts that the datetime is close to the expected datetime within the specified tolerance.
    /// </summary>
    public static void BeCloseTo(this DateTime value, DateTime expected, TimeSpan tolerance)
    {
        var difference = (value - expected).Duration();
        if (difference > tolerance)
            VolubleScope.FailWith($"Expected {value:O} to be close to {expected:O} (±{tolerance}) but difference was {difference}");
    }

    #endregion

    #region Component Assertions

    /// <summary>
    /// Asserts that the datetime has the specified year.
    /// </summary>
    public static void HaveYear(this DateTime value, int year)
    {
        if (value.Year != year)
            VolubleScope.FailWith($"Expected {value:O} to have year {year} but was {value.Year}");
    }

    /// <summary>
    /// Asserts that the datetime has the specified month.
    /// </summary>
    public static void HaveMonth(this DateTime value, int month)
    {
        if (value.Month != month)
            VolubleScope.FailWith($"Expected {value:O} to have month {month} but was {value.Month}");
    }

    /// <summary>
    /// Asserts that the datetime has the specified day.
    /// </summary>
    public static void HaveDay(this DateTime value, int day)
    {
        if (value.Day != day)
            VolubleScope.FailWith($"Expected {value:O} to have day {day} but was {value.Day}");
    }

    /// <summary>
    /// Asserts that the datetime has the specified hour.
    /// </summary>
    public static void HaveHour(this DateTime value, int hour)
    {
        if (value.Hour != hour)
            VolubleScope.FailWith($"Expected {value:O} to have hour {hour} but was {value.Hour}");
    }

    /// <summary>
    /// Asserts that the datetime has the specified minute.
    /// </summary>
    public static void HaveMinute(this DateTime value, int minute)
    {
        if (value.Minute != minute)
            VolubleScope.FailWith($"Expected {value:O} to have minute {minute} but was {value.Minute}");
    }

    /// <summary>
    /// Asserts that the datetime has the specified second.
    /// </summary>
    public static void HaveSecond(this DateTime value, int second)
    {
        if (value.Second != second)
            VolubleScope.FailWith($"Expected {value:O} to have second {second} but was {value.Second}");
    }

    /// <summary>
    /// Asserts that the datetime has the specified date (ignoring time).
    /// </summary>
    public static void HaveDate(this DateTime value, int year, int month, int day)
    {
        if (value.Year != year || value.Month != month || value.Day != day)
            VolubleScope.FailWith($"Expected {value:O} to have date {year}-{month:D2}-{day:D2} but was {value:yyyy-MM-dd}");
    }

    /// <summary>
    /// Asserts that the datetime has the specified time (ignoring date).
    /// </summary>
    public static void HaveTime(this DateTime value, int hour, int minute, int second = 0)
    {
        if (value.Hour != hour || value.Minute != minute || value.Second != second)
            VolubleScope.FailWith($"Expected {value:O} to have time {hour:D2}:{minute:D2}:{second:D2} but was {value:HH:mm:ss}");
    }

    #endregion

    #region Day of Week Assertions

    /// <summary>
    /// Asserts that the datetime is on the specified day of week.
    /// </summary>
    public static void BeOnDayOfWeek(this DateTime value, DayOfWeek dayOfWeek)
    {
        if (value.DayOfWeek != dayOfWeek)
            VolubleScope.FailWith($"Expected {value:O} to be on {dayOfWeek} but was {value.DayOfWeek}");
    }

    /// <summary>
    /// Asserts that the datetime is on a weekend (Saturday or Sunday).
    /// </summary>
    public static void BeOnWeekend(this DateTime value)
    {
        if (value.DayOfWeek != DayOfWeek.Saturday && value.DayOfWeek != DayOfWeek.Sunday)
            VolubleScope.FailWith($"Expected {value:O} to be on weekend but was {value.DayOfWeek}");
    }

    /// <summary>
    /// Asserts that the datetime is on a weekday (Monday through Friday).
    /// </summary>
    public static void BeOnWeekday(this DateTime value)
    {
        if (value.DayOfWeek == DayOfWeek.Saturday || value.DayOfWeek == DayOfWeek.Sunday)
            VolubleScope.FailWith($"Expected {value:O} to be on weekday but was {value.DayOfWeek}");
    }

    #endregion

    #region DateTimeOffset Assertions

    /// <summary>
    /// Asserts that the datetimeoffset is after the specified datetimeoffset.
    /// </summary>
    public static void BeAfter(this DateTimeOffset value, DateTimeOffset other)
    {
        if (value <= other)
            VolubleScope.FailWith($"Expected {value:O} to be after {other:O}");
    }

    /// <summary>
    /// Asserts that the datetimeoffset is before the specified datetimeoffset.
    /// </summary>
    public static void BeBefore(this DateTimeOffset value, DateTimeOffset other)
    {
        if (value >= other)
            VolubleScope.FailWith($"Expected {value:O} to be before {other:O}");
    }

    /// <summary>
    /// Asserts that the datetimeoffset is on or after the specified datetimeoffset.
    /// </summary>
    public static void BeOnOrAfter(this DateTimeOffset value, DateTimeOffset other)
    {
        if (value < other)
            VolubleScope.FailWith($"Expected {value:O} to be on or after {other:O}");
    }

    /// <summary>
    /// Asserts that the datetimeoffset is on or before the specified datetimeoffset.
    /// </summary>
    public static void BeOnOrBefore(this DateTimeOffset value, DateTimeOffset other)
    {
        if (value > other)
            VolubleScope.FailWith($"Expected {value:O} to be on or before {other:O}");
    }

    /// <summary>
    /// Asserts that the datetimeoffset is close to the expected datetimeoffset within the specified tolerance.
    /// </summary>
    public static void BeCloseTo(this DateTimeOffset value, DateTimeOffset expected, TimeSpan tolerance)
    {
        var difference = (value - expected).Duration();
        if (difference > tolerance)
            VolubleScope.FailWith($"Expected {value:O} to be close to {expected:O} (±{tolerance}) but difference was {difference}");
    }

    #endregion
}
