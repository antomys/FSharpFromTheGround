FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CollectionFunctionsAe/CollectionFunctionsAe.fsproj", "CollectionFunctionsAe/"]
RUN dotnet restore "CollectionFunctionsAe/CollectionFunctionsAe.fsproj"
COPY . .
WORKDIR "/src/CollectionFunctionsAe"
RUN dotnet build "CollectionFunctionsAe.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollectionFunctionsAe.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollectionFunctionsAe.dll"]
