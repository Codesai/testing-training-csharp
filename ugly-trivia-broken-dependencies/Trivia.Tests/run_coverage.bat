@echo off
echo =======================================================
echo Running .NET tests and collecting coverage...
echo =======================================================
dotnet test /p:CollectCoverage=true /p:CoverletOutput=coverage/data/coverage /p:CoverletOutputFormat=cobertura

echo.
echo =======================================================
echo Generating coverage report...
echo =======================================================
dotnet reportgenerator -reports:coverage/data/coverage.cobertura.xml -targetdir:coverage/report

echo.
echo Process finished.