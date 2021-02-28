FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore Rnc-backend.csproj
COPY . ./
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/runtime:5.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [“dotnet”, “Rnc-backend.dll”]`