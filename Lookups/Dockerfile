FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Lookups/Lookups.fsproj", "Lookups/"]
RUN dotnet restore "Lookups/Lookups.fsproj"
COPY . .
WORKDIR "/src/Lookups"
RUN dotnet build "Lookups.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lookups.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lookups.dll"]
