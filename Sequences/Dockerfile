FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sequences/Sequences.fsproj", "Sequences/"]
RUN dotnet restore "Sequences/Sequences.fsproj"
COPY . .
WORKDIR "/src/Sequences"
RUN dotnet build "Sequences.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sequences.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sequences.dll"]
