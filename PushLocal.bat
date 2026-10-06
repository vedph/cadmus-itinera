@echo off
echo PRESS ANY KEY TO INSTALL Cadmus Libraries TO LOCAL NUGET FEED
echo Remember to generate the up-to-date package.
c:\exe\nuget add .\Cadmus.Itinera.Parts\bin\Release\Cadmus.Itinera.Parts.9.0.4.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Itinera.Services\bin\Release\Cadmus.Itinera.Services.9.0.4.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Seed.Itinera.Parts\bin\Release\Cadmus.Seed.Itinera.Parts.9.0.4.nupkg -source C:\Projects\_NuGet
pause
