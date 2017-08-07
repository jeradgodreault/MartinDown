# MartinDown
A parser for a small subset of markdown.
[![Build Status](https://travis-ci.org/jeradgodreault/MartinDown.svg?branch=master)](https://travis-ci.org/jeradgodreault/MartinDown) [![Code Climate](https://codeclimate.com/github/jeradgodreault/MartinDown/badges/gpa.svg)](https://codeclimate.com/github/jeradgodreault/MartinDown) [![Test Coverage](https://codeclimate.com/github/jeradgodreault/MartinDown/badges/coverage.svg)](https://codeclimate.com/github/jeradgodreault/MartinDown/coverage)

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

### Prerequisites
There are multiple ways to build this project. This guide will be using the .NET Core command-line interface (CLI) tools. 

### Installing

```dos
cd ./src
dotnet restore
dotnet build
```

## Demo
This is how you would use MartinDown in your project.

```cs
using System;

namespace Godreault.MartinDown
{
    public class Program
    {
        static void Main(string[] args) 
        {
            MarkDown markdown = new MarkDown();
            Console.WriteLine(markdown.Transform("Hello World!"));
        }
    }
}
```

# Running the tests
Here's how to run the automated tests for this MartinDown.

```dos 
cd ./tests/
dotnet restore
dotnet test
```

# Contributing
Contributions are absolutely welcome! The project is built as a .NET Core library. You'll need to download this to build the project.

- Fork it!
- Create your feature branch: `git checkout -b my-new-feature`
- Commit your changes: `git commit -am 'Add some feature'`
- Push to the branch: `git push origin my-new-feature`
- Submit a pull request.

## Versioning
We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/jeradgodreault/MartinDown/tags). 

## Authors
* **Jerad Godreault** - *Initial work* - [PurpleBooth](https://github.com/jeradgodreault)

See also the list of [contributors](https://github.com/jeradgodreault/MartinDown/contributors) who participated in this project.

## License
This project is licensed under the **Apache License 2.0** - see the [LICENSE.md](LICENSE.md) file for details