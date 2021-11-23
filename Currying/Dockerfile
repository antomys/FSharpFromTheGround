FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Currying/Currying.fsproj", "Currying/"]
RUN dotnet restore "Currying/Currying.fsproj"
COPY . .
WORKDIR "/src/Currying"
RUN dotnet build "Currying.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Currying.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Currying.dll"]
