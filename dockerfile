#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Api.Rnc/Api.Rnc.csproj", "Api.Rnc/"]
COPY ["Data.Rnc/Data.Rnc.csproj", "Data.Rnc/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "Api.Rnc/Api.Rnc.csproj"
COPY . .
WORKDIR "/src/Api.Rnc"
RUN dotnet build "Api.Rnc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Rnc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Rnc.dll"]