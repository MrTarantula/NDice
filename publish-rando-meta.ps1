param (
    [string]$key = ""
)

dotnet pack .\NDice.Randomizers\NDice.Randomizers -c Release -o ..\..\build\meta

dotnet nuget push .\build\meta\ -k $key -s https://api.nuget.org/v3/index.json
