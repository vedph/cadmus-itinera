@echo off
echo BUILD Cadmus Itinera Packages
del .\Cadmus.Itinera.Parts\bin\Release\*.snupkg
del .\Cadmus.Itinera.Parts\bin\Release\*.nupkg

del .\Cadmus.Itinera.Services\bin\Release\*.snupkg
del .\Cadmus.Itinera.Services\bin\Release\*.nupkg

del .\Cadmus.Seed.Itinera.Parts\bin\Release\*.snupkg
del .\Cadmus.Seed.Itinera.Parts\bin\Release\*.nupkg

cd .\Cadmus.Itinera.Parts
dotnet pack -c Release -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.Itinera.Services
dotnet pack -c Release -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.Seed.Itinera.Parts
dotnet pack -c Release -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

pause
