Notice - This library is essentially made as a joke, feel free to use it but as of now I do not guarantee updates. Consider using Shouldly.

# Voluble
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

