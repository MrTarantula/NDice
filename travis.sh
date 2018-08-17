dotnet pack ./NDice -c Release -o ../build/ndice
dotnet nuget push ./build/ndice/ -k $nuget -s https://api.nuget.org/v3/index.json

sleep 5m

dotnet pack ./NDice.Randomizers/NDice.Randomizers.RandomOrg -c Release -o ../../build/rando
dotnet pack ./NDice.Randomizers/NDice.Randomizers.Troschuetz -c Release -o ../../build/rando
dotnet pack ./NDice.Randomizers/NDice.Randomizers.SystemCrypto -c Release -o ../../build/rando

for file in ./build/rando/*; do
    dotnet nuget push ./build/rando/$file -k $nuget -s https://api.nuget.org/v3/index.json
done

sleep 5m

dotnet pack ./NDice.Randomizers/NDice.Randomizers -c Release -o ../../build/meta
dotnet nuget push ./build/meta/ -k $nuget -s https://api.nuget.org/v3/index.json