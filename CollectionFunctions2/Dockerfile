FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CollectionFunctions2/CollectionFunctions2.fsproj", "CollectionFunctions2/"]
RUN dotnet restore "CollectionFunctions2/CollectionFunctions2.fsproj"
COPY . .
WORKDIR "/src/CollectionFunctions2"
RUN dotnet build "CollectionFunctions2.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollectionFunctions2.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollectionFunctions2.dll"]
