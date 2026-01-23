# Voluble [![Build and Test](https://github.com/infroz/Voluble/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/infroz/Voluble/actions/workflows/build-and-test.yml) [![NuGet Version](https://img.shields.io/nuget/v/Voluble)](https://www.nuget.org/packages/Voluble/)

An open-sourced alternative to expressive assertions.

Notice - This library was made as a test to see how easy it was to create expressive assertions and a bit of jab at another library whom shall not be named. Consider using Shouldly, but feel free to test this library if you want to.

Definition
```quote
(adjective)
(of a person) talking fluently, readily, or incessantly.
"a voluble game-show host"
or.
an assertion library not costing 130$ per seat.
```


## Installation
Dotnet-Cli
```bash
dotnet add package Voluble
```

## Features

- Fluent assertion syntax with `.Should()` entry point
- Chainable assertions
- String assertions (contains, starts/ends with, regex matching, length)
- Numeric assertions (comparisons, ranges, sign, approximations)
- Collection assertions (contains, count, ordering, equivalence)
- DateTime assertions (before/after, components, day of week)
- Type assertions (exact type, assignability)
- Exception assertions (sync and async)
- Custom failure messages with `because` parameter
- `VolubleScope` for collecting multiple assertion failures

## Usage

### Basic Assertions
```csharp
"hello".Should().Be("hello");
42.Should().NotBe(0);
myObject.Should().NotBeNull();
```

### String Assertions
```csharp
"hello world".Should().Contain("world");
"hello world".Should().StartWith("hello");
"hello world".Should().EndWith("world");
"hello world".Should().Match(@"hello \w+");
"hello".Should().HaveLength(5);
"".Should().BeNullOrEmpty();
```

### Numeric Assertions
```csharp
42.BeGreaterThan(0);
42.BeLessThanOrEqualTo(100);
42.BeInRange(1, 50);
3.14.BeApproximately(Math.PI, tolerance: 0.01);
(-5).BeNegative();
0.BeZero();
```

### Collection Assertions
```csharp
var list = new[] { 1, 2, 3 };
list.Contain(2);
list.NotContain(5);
list.HaveCount(3);
list.NotBeEmpty();
list.BeInAscendingOrder();
list.ContainSingle(x => x > 2);
list.BeEquivalentTo(new[] { 3, 1, 2 }); // order independent
```

### DateTime Assertions
```csharp
DateTime.Now.BeAfter(DateTime.MinValue);
DateTime.Now.BeOnWeekday();
someDate.HaveYear(2025);
someDate.BeCloseTo(expectedDate, TimeSpan.FromSeconds(1));
```

### Exception Assertions
```csharp
Action act = () => throw new InvalidOperationException();
act.Should().Throw<InvalidOperationException>();

Func<Task> asyncAct = async () => await FailingMethodAsync();
await asyncAct.Should().ThrowAsync<InvalidOperationException>();
```

### Type Assertions
```csharp
object obj = "hello";
obj.Should().BeOfType<string>();
obj.Should().BeAssignableTo<IEnumerable<char>>();
```

### Custom Failure Messages
```csharp
price.Should().Be(0, because: "the cart is empty");
```

### VolubleScope - Collect Multiple Failures
By default, assertions fail immediately. Use `VolubleScope` to collect all failures and report them together at the end:
```csharp
using (new VolubleScope())
{
    1.Should().Be(2);  // collected, doesn't throw yet
    "a".Should().Be("b");  // collected
}  // throws here with all failures
```

## Requirements

- .NET 9.0 or .NET 10.0

## License

[Apache 2.0](LICENSE.md)
