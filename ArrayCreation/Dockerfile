FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ArrayCreation/ArrayCreation.fsproj", "ArrayCreation/"]
RUN dotnet restore "ArrayCreation/ArrayCreation.fsproj"
COPY . .
WORKDIR "/src/ArrayCreation"
RUN dotnet build "ArrayCreation.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArrayCreation.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArrayCreation.dll"]
