# Voluble [![Build and Test](https://github.com/infroz/Voluble/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/infroz/Voluble/actions/workflows/build-and-test.yml) ![NuGet Version](https://img.shields.io/nuget/v/Voluble)

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

## Usage
```csharp
// Simple Assertion
0.Should().NotBe(130);

// Collect all errors
using (new VolubleScope()) {
    "syntactic sugar".Should().Be("syntactic sugar");
}
```

