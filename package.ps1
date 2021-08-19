dotnet clean
dotnet pack --include-source --configuration Release

# Find it at https://www.nuget.org/account/apikeys
$NugetApiKey = ""
$PackageSymbols = ls "C:\git\ChallongeNetCore\src\ChallongeNetCore\bin\Release\ChallongeNetCore.*.symbols.nupkg" | select -First 1 | select -expand FullName
dotnet nuget push $PackageSymbols --api-key $NugetApiKey -s https://api.nuget.org/v3/index.json