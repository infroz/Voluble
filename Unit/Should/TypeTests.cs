using Voluble.Exceptions;

namespace Voluble.Unit.Should;

public class TypeTests
{
    #region Test Classes

    private class Animal { }
    private class Dog : Animal { }
    private class Cat : Animal { }
    private interface ICanBark { }
    private class BarkingDog : Dog, ICanBark { }

    #endregion

    #region BeOfType

    [Fact]
    public void BeOfType_WhenExactTypeMatches_ShouldNotThrow()
    {
        object value = "hello";
        var act = () => value.Should().BeOfType<string>();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeOfType_WhenTypeDoesNotMatch_ShouldThrow()
    {
        object value = "hello";
        var act = () => value.Should().BeOfType<int>();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeOfType_WhenDerivedType_ShouldThrow()
    {
        // Dog is derived from Animal, but BeOfType requires exact match
        object value = new Dog();
        var act = () => value.Should().BeOfType<Animal>();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeOfType_WhenExactDerivedType_ShouldNotThrow()
    {
        object value = new Dog();
        var act = () => value.Should().BeOfType<Dog>();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeOfType_WhenNull_ShouldThrow()
    {
        object? value = null;
        var act = () => value.Should().BeOfType<string>();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeOfType_WithInt_ShouldWork()
    {
        object value = 42;
        var act = () => value.Should().BeOfType<int>();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region NotBeOfType

    [Fact]
    public void NotBeOfType_WhenTypeDoesNotMatch_ShouldNotThrow()
    {
        object value = "hello";
        var act = () => value.Should().NotBeOfType<int>();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotBeOfType_WhenExactTypeMatches_ShouldThrow()
    {
        object value = "hello";
        var act = () => value.Should().NotBeOfType<string>();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void NotBeOfType_WhenDerivedType_ShouldNotThrow()
    {
        // Dog is not exactly Animal, so this should pass
        object value = new Dog();
        var act = () => value.Should().NotBeOfType<Animal>();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotBeOfType_WhenNull_ShouldNotThrow()
    {
        object? value = null;
        var act = () => value.Should().NotBeOfType<string>();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region BeAssignableTo

    [Fact]
    public void BeAssignableTo_WhenExactType_ShouldNotThrow()
    {
        object value = new Dog();
        var act = () => value.Should().BeAssignableTo<Dog>();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeAssignableTo_WhenDerivedFromBaseClass_ShouldNotThrow()
    {
        object value = new Dog();
        var act = () => value.Should().BeAssignableTo<Animal>();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeAssignableTo_WhenImplementsInterface_ShouldNotThrow()
    {
        object value = new BarkingDog();
        var act = () => value.Should().BeAssignableTo<ICanBark>();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void BeAssignableTo_WhenNotAssignable_ShouldThrow()
    {
        object value = new Cat();
        var act = () => value.Should().BeAssignableTo<Dog>();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeAssignableTo_WhenNull_ShouldThrow()
    {
        object? value = null;
        var act = () => value.Should().BeAssignableTo<Animal>();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void BeAssignableTo_WhenStringToObject_ShouldNotThrow()
    {
        object value = "hello";
        var act = () => value.Should().BeAssignableTo<object>();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion

    #region NotBeAssignableTo

    [Fact]
    public void NotBeAssignableTo_WhenNotAssignable_ShouldNotThrow()
    {
        object value = new Cat();
        var act = () => value.Should().NotBeAssignableTo<Dog>();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotBeAssignableTo_WhenExactType_ShouldThrow()
    {
        object value = new Dog();
        var act = () => value.Should().NotBeAssignableTo<Dog>();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void NotBeAssignableTo_WhenDerivedFromBaseClass_ShouldThrow()
    {
        object value = new Dog();
        var act = () => value.Should().NotBeAssignableTo<Animal>();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void NotBeAssignableTo_WhenImplementsInterface_ShouldThrow()
    {
        object value = new BarkingDog();
        var act = () => value.Should().NotBeAssignableTo<ICanBark>();

        Assert.Throws<Failure>(act);
    }

    [Fact]
    public void NotBeAssignableTo_WhenNull_ShouldNotThrow()
    {
        object? value = null;
        var act = () => value.Should().NotBeAssignableTo<Animal>();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Fact]
    public void NotBeAssignableTo_WhenDoesNotImplementInterface_ShouldNotThrow()
    {
        object value = new Dog(); // Dog does not implement ICanBark, only BarkingDog does
        var act = () => value.Should().NotBeAssignableTo<ICanBark>();

        var exception = Record.Exception(act);
        Assert.Null(exception);
    }

    #endregion
}
