FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CollectionFunctions/CollectionFunctions.fsproj", "CollectionFunctions/"]
RUN dotnet restore "CollectionFunctions/CollectionFunctions.fsproj"
COPY . .
WORKDIR "/src/CollectionFunctions"
RUN dotnet build "CollectionFunctions.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollectionFunctions.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollectionFunctions.dll"]
