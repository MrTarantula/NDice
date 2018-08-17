dotnet pack ./NDice.Randomizers/NDice.Randomizers.RandomOrg -c Release -o ../../build/rando
dotnet pack ./NDice.Randomizers/NDice.Randomizers.Troschuetz -c Release -o ../../build/rando
dotnet pack ./NDice.Randomizers/NDice.Randomizers.SystemCrypto -c Release -o ../../build/rando

for file in ./build/rando/*; do
    dotnet nuget push ./build/rando/$file -k $1 -s https://api.nuget.org/v3/index.json
done