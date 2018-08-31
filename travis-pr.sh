#!/bin/bash

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=../ndice.coverage.xml ./NDice.Tests --filter Category!=Uniformity
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=../ndice.randomizers.coverage.xml ./NDice.Randomizers.Tests --filter Category!=Uniformity