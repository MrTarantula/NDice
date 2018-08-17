version=0.6.3

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=../ndice.coverage.xml ./NDice.Tests --filter Category!=Uniformity
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=../ndice.randomizers.coverage.xml ./NDice.Randomizers.Tests --filter Category!=Uniformity

dotnet pack ./NDice -c Release /p:PackageVersion=$version -o ../build/ndice
dotnet nuget push ./build/ndice/ -k $nuget -s https://api.nuget.org/v3/index.json

#sleep 8m

dotnet pack ./NDice.Randomizers/NDice.Randomizers.RandomOrg -c Release /p:PackageVersion=$version -o ../../build/rando
dotnet pack ./NDice.Randomizers/NDice.Randomizers.Troschuetz -c Release /p:PackageVersion=$version -o ../../build/rando
dotnet pack ./NDice.Randomizers/NDice.Randomizers.SystemCrypto -c Release /p:PackageVersion=$version -o ../../build/rando

for file in ./build/rando/*.nupkg; do
    dotnet nuget push $file -k $nuget -s https://api.nuget.org/v3/index.json
done

#sleep 8m

dotnet pack ./NDice.Randomizers/NDice.Randomizers -c Release /p:PackageVersion=$version -o ../../build/meta
dotnet nuget push ./build/meta/ -k $nuget -s https://api.nuget.org/v3/index.json
