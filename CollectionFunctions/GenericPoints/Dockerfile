FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GenericPoints/GenericPoints.fsproj", "GenericPoints/"]
RUN dotnet restore "GenericPoints/GenericPoints.fsproj"
COPY . .
WORKDIR "/src/GenericPoints"
RUN dotnet build "GenericPoints.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GenericPoints.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GenericPoints.dll"]
