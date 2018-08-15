param (
    [string]$key = ""
)

dotnet pack .\NDice -c Release -o ..\nuget\ndice

dotnet nuget push .\nuget\ndice\ -k $key -s https://api.nuget.org/v3/index.json
