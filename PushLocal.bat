@echo off
echo PRESS ANY KEY TO INSTALL Cadmus Libraries TO LOCAL NUGET FEED
echo Remember to generate the up-to-date package.
c:\exe\nuget add .\Cadmus.Itinera.Parts\bin\Debug\Cadmus.Itinera.Parts.4.1.5.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Itinera.Services\bin\Debug\Cadmus.Itinera.Services.4.1.5.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Seed.Itinera.Parts\bin\Debug\Cadmus.Seed.Itinera.Parts.4.1.5.nupkg -source C:\Projects\_NuGet
pause
