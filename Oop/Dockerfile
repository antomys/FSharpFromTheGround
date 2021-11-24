FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Oop/Oop.fsproj", "Oop/"]
RUN dotnet restore "Oop/Oop.fsproj"
COPY . .
WORKDIR "/src/Oop"
RUN dotnet build "Oop.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Oop.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Oop.dll"]
