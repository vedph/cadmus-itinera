# build
dotnet build -c Release
# publish library
Remove-Item -Path .\Cadmus.Itinera.Services\bin\Release\net10.0\publish -Recurse -Force
dotnet publish .\Cadmus.Itinera.Services\Cadmus.Itinera.Services.csproj -c Release
# rename publish to Cadmus.Itinera.Services and zip
Rename-Item -Path .\Cadmus.Itinera.Services\bin\Release\net10.0\publish -NewName Cadmus.Itinera.Services
compress-archive -path .\Cadmus.Itinera.Services\bin\Release\net10.0\Cadmus.Itinera.Services\ -DestinationPath .\Cadmus.Itinera.Services\bin\Release\net10.0\Cadmus.Itinera.Services.zip -Force
# rename back
Rename-Item -Path .\Cadmus.Itinera.Services\bin\Release\net10.0\Cadmus.Itinera.Services -NewName publish
