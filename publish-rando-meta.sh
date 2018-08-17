dotnet pack ./NDice.Randomizers/NDice.Randomizers -c Release -o ../../build/meta

dotnet nuget push ./build/meta/ -k $1 -s https://api.nuget.org/v3/index.json