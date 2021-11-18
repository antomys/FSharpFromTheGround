FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ControlFlow/ControlFlow.fsproj", "ControlFlow/"]
RUN dotnet restore "ControlFlow/ControlFlow.fsproj"
COPY . .
WORKDIR "/src/ControlFlow"
RUN dotnet build "ControlFlow.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ControlFlow.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ControlFlow.dll"]
