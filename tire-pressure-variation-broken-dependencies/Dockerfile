FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

# To make the Dockerfile general, we copy all files at once.
# This ensures it works with any project name (e.g., CourseDuration or KataTirePressureVariation)
# without needing to modify the Dockerfile for each new project.
COPY . .

# Restore NuGet packages and local dotnet tools
RUN dotnet restore
RUN dotnet tool restore

# Dynamically find the test project and run the 'Coverlet' target.
# This avoids hardcoding project names or paths in the entry point.
ENTRYPOINT ["sh", "-c", "PROJECT=$(find . -name '*.Test.csproj' | head -n 1); dotnet msbuild \"$PROJECT\" -t:Coverlet"]
