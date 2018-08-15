param (
    [string]$key = ""
)

dotnet pack .\NDice.Randomizers\NDice.Randomizers -c Release -o ..\..\nuget\meta

dotnet nuget push .\nuget\meta\ -k $key -s https://api.nuget.org/v3/index.json
