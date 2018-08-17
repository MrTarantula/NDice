dotnet pack ./NDice -c Release -o ../build/ndice

dotnet nuget push ./build/ndice/ -k $1 -s https://api.nuget.org/v3/index.json