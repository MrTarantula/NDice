param (
    [string]$key = ""
)

dotnet pack .\NDice.Randomizers\NDice.Randomizers.RandomOrg -c Release -o ..\..\build\rando
dotnet pack .\NDice.Randomizers\NDice.Randomizers.Troschuetz -c Release -o ..\..\build\rando
dotnet pack .\NDice.Randomizers\NDice.Randomizers.SystemCrypto -c Release -o ..\..\build\rando

$files = Get-ChildItem -Name .\build\rando

foreach ($file in $files) {
    dotnet nuget push .\build\rando\$file -k $key -s https://api.nuget.org/v3/index.json
}