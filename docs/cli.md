# Reference notes of useful console commands for the project

Assuming terminal is in the src folder.

## Compilation

### Restore all dependent NuGet packages

``` dos
dotnet restore
```

### Compile all projects in the solution

``` dos
dotnet build
```

## Testing

### Run all tests

``` dos
dotnet test ./CassinoGames.Test/CassinoGames.Test.csproj
```

### Run all tests when code chanes

Runs all the unit tests, any time a code file changes in the test project or its referenced dependencies.

``` dos
dotnet watch --project .\CasinoGames.Test\CasinoGames.Test.csproj tes
```
