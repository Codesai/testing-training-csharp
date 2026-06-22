# Tire Pressure Monitoring System Variation

## Goal

Be able to make characterization tests for `Alarm`'s `check` function without changing the method signature.

## References

Based on an exercise from [Luca Minudel](https://twitter.com/lukadotnet?lang=en)'s [TDD with Mock Objects And Design Principles exercises](https://github.com/lucaminudel/TDDwithMockObjectsAndDesignPrinciples)

## Tools
### Install dependencies and tools

`dotnet restore`

### Coverage
Run as msbuild target with this command:

`dotnet msbuild -target:Coverlet`

Or execute the .bat script in test project with:

`.\coverage.bat`

### Mutation testing

Run this command from solution folder

`dotnet stryker --open-report`

## Coverage with docker

`docker build -t coverlet . && docker run --rm -v "$PWD/coverage:/app/coverage" coverlet`


## References

Based on an exercise from [Luca Minudel](https://twitter.com/lukadotnet?lang=en)'s [TDD with Mock Objects And Design Principles exercises](https://github.com/lucaminudel/TDDwithMockObjectsAndDesignPrinciples)
