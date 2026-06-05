FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/FCG.NotificationsAPI/FCG.NotificationsAPI.csproj src/FCG.NotificationsAPI/
RUN dotnet restore src/FCG.NotificationsAPI/FCG.NotificationsAPI.csproj

COPY . .
RUN dotnet publish src/FCG.NotificationsAPI/FCG.NotificationsAPI.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FCG.NotificationsAPI.dll"]
