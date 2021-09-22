#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/4Lab.WebApi/4Lab.WebApi.csproj", "src/4Lab.WebApi/"]
COPY ["src/4Lab.Orchestrator/4Lab.Orchestrator.csproj", "src/4Lab.Orchestrator/"]
COPY ["src/4Lab.Archives.Application/4Lab.Archives.Application.csproj", "src/4Lab.Archives.Application/"]
COPY ["src/4Lab.Archives.Domain/4Lab.Archives.Domain.csproj", "src/4Lab.Archives.Domain/"]
COPY ["src/4Lab.Core/4Lab.Core.csproj", "src/4Lab.Core/"]
COPY ["src/4Lab.Infrastructure.Storage/4Lab.Infrastructure.Storage.csproj", "src/4Lab.Infrastructure.Storage/"]
COPY ["src/4Lab.Archives.Data/4Lab.Archives.Data.csproj", "src/4Lab.Archives.Data/"]
COPY ["src/4Lab.Occurrences.Application/4Lab.Occurrences.Application.csproj", "src/4Lab.Occurrences.Application/"]
COPY ["src/4Lab.Infrastructure.Render/4Lab.Infrastructure.Render.csproj", "src/4Lab.Infrastructure.Render/"]
COPY ["src/4Lab.Infrastructure.Charts/4Lab.Infrastructure.Charts.csproj", "src/4Lab.Infrastructure.Charts/"]
COPY ["src/4Lab.Occurrences.Data/4Lab.Occurrences.Data.csproj", "src/4Lab.Occurrences.Data/"]
COPY ["src/4Lab.Occurrences.Domain/4Lab.Occurrences.Domain.csproj", "src/4Lab.Occurrences.Domain/"]
COPY ["src/4Lab.Administration.Application/4Lab.Administration.Application.csproj", "src/4Lab.Administration.Application/"]
COPY ["src/4Lab.Administration.Domain/4Lab.Administration.Domain.csproj", "src/4Lab.Administration.Domain/"]
COPY ["src/4Lab.Administration.Data/4Lab.Administration.Data.csproj", "src/4Lab.Administration.Data/"]
COPY ["src/4Lab.CrossCutting/4Lab.CrossCutting.csproj", "src/4Lab.CrossCutting/"]
COPY ["src/4Lab.Infrastructure.Authorization/4Lab.Infrastructure.Authorization.csproj", "src/4Lab.Infrastructure.Authorization/"]
COPY ["src/4Lab.Infrastructure.Smtp/4Lab.Infrastructure.Smtp.csproj", "src/4Lab.Infrastructure.Smtp/"]
RUN dotnet restore "src/4Lab.WebApi/4Lab.WebApi.csproj"
COPY . .
WORKDIR "/src/src/4Lab.WebApi"
RUN dotnet build "4Lab.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "4Lab.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "4Lab.WebApi.dll"]