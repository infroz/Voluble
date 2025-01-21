namespace Voluble.Unit.Should.BeEquivalentTo;

public class PrimitiveObjectTests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(-2, -2)]
    [InlineData(1.1, 1.1)]
    [InlineData(1.0D, 1.0D)]
    [InlineData(1L, 1L)]
    [InlineData("TEST", "TEST")]
    public void APrimitiveValue_IsEqualToAnother_Success(object actual, object expected)
    {
        // Expect not to fail...
        actual.Should().BeEquivalentTo(expected);
    }
}