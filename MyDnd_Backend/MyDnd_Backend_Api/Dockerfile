FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyDnd_Backend_Api/MyDnd_Backend_Api.csproj", "MyDnd_Backend_Api/"]
RUN dotnet restore "MyDnd_Backend_Api/MyDnd_Backend_Api.csproj"
COPY . .
WORKDIR "/src/MyDnd_Backend_Api"
RUN dotnet build "MyDnd_Backend_Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyDnd_Backend_Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyDnd_Backend_Api.dll"]
