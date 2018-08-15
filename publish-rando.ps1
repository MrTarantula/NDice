param (
    [string]$key = ""
)

dotnet pack .\NDice.Randomizers\NDice.Randomizers.RandomOrg -c Release -o ..\..\nuget\rando
dotnet pack .\NDice.Randomizers\NDice.Randomizers.Troschuetz -c Release -o ..\..\nuget\rando
dotnet pack .\NDice.Randomizers\NDice.Randomizers.SystemCrypto -c Release -o ..\..\nuget\rando

$files = Get-ChildItem -Name .\nuget\rando

foreach ($file in $files) {
    dotnet nuget push .\nuget\rando\$file -k $key -s https://api.nuget.org/v3/index.json
}