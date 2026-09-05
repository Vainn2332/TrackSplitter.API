FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY TrackSplitter.API/TrackSplitter.API.csproj TrackSplitter.API/
COPY TrackSplitter.BusinessLogic/TrackSplitter.BusinessLogic.csproj TrackSplitter.BusinessLogic/
COPY TrackSplitter.DataAccess/TrackSplitter.DataAccess.csproj TrackSplitter.DataAccess/
COPY TrackSplitter.Messages/TrackSplitter.Messages.csproj TrackSplitter.Messages/

RUN dotnet restore TrackSplitter.API/TrackSplitter.API.csproj

COPY . .
RUN dotnet publish TrackSplitter.API/TrackSplitter.API.csproj \
    -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080

USER app

ENTRYPOINT ["dotnet", "TrackSplitter.API.dll"]
