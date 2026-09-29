@echo off
echo PUSH PACKAGES TO NUGET
prompt
set nu=C:\Exe\nuget.exe
set src=-Source https://api.nuget.org/v3/index.json

%nu% push .\Cadmus.Itinera.Parts\bin\Release\*.nupkg %src% -SkipDuplicate
%nu% push .\Cadmus.Itinera.Services\bin\Release\*.nupkg %src% -SkipDuplicate
%nu% push .\Cadmus.Seed.Itinera.Parts\bin\Release\*.nupkg %src% -SkipDuplicate
echo COMPLETED
echo on
