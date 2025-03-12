namespace Voluble.Unit.Should.BeEquivalentTo;

public class PartialClassMatchOnFullClass
{
    [Fact]
    public void PartialClassExpected_FullClassActual_Success()
    {
        var actual = new
        {
            MyString = "TEST",
            MyInt = 1,
            MyString2 = "TEST2"
        };

        actual.Should().BeEquivalentTo(new
        {
            MyString = "TEST"
        });
        actual.Should().BeEquivalentTo(new
        {
            MyInt = 1,
            MyString2 = "TEST2"
        });
    }

    [Fact]
    public void PartialClassExpected_OnFullClassWithWrongProperties_Failure()
    {
        var actual = new
        {
            MyString = "TEST",
            MyInt = 1,
            MyString2 = "TEST2"
        };
        var act = () => actual.Should().BeEquivalentTo(new { MyBool = false });

        var throws = false;
        try
        {
            act.Invoke();
        }
        catch (Exception)
        {
            throws = true;
        }

        Assert.True(throws);
    }
}