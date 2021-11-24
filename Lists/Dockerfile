FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Lists/Lists.fsproj", "Lists/"]
RUN dotnet restore "Lists/Lists.fsproj"
COPY . .
WORKDIR "/src/Lists"
RUN dotnet build "Lists.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lists.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lists.dll"]
