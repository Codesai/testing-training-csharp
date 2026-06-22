# Ugly Trivia 

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