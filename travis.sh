#!/bin/bash
version=0.8.1

if [ $TRAVIS_PULL_REQUEST="false" ]
then
    dotnet pack ./NDice -c Release /p:PackageVersion=$version -o ../build/ndice
    dotnet nuget push ./build/ndice/ -k $nugetkey -s https://api.nuget.org/v3/index.json

    sleep 5m

    dotnet pack ./NDice.Randomizers/NDice.Randomizers.RandomOrg -c Release /p:PackageVersion=$version -o ../../build/rando
    dotnet pack ./NDice.Randomizers/NDice.Randomizers.Troschuetz -c Release /p:PackageVersion=$version -o ../../build/rando
    dotnet pack ./NDice.Randomizers/NDice.Randomizers.SystemCrypto -c Release /p:PackageVersion=$version -o ../../build/rando

    for file in ./build/rando/*.nupkg; do
        dotnet nuget push $file -k $nugetkey -s https://api.nuget.org/v3/index.json
    done

    sleep 5m

    dotnet pack ./NDice.Randomizers/NDice.Randomizers -c Release /p:PackageVersion=$version -o ../../build/meta
    dotnet nuget push ./build/meta/ -k $nugetkey -s https://api.nuget.org/v3/index.json
fi

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=../ndice.coverage.xml ./NDice.Tests --filter Category!=Uniformity
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=../ndice.randomizers.coverage.xml ./NDice.Randomizers.Tests --filter Category!=Uniformity