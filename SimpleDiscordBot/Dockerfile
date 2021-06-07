FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SimpleDiscordBot/SimpleDiscordBot.csproj", "SimpleDiscordBot/"]
RUN dotnet restore "SimpleDiscordBot/SimpleDiscordBot.csproj"
COPY . .
WORKDIR "/src/SimpleDiscordBot"
RUN dotnet build "SimpleDiscordBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleDiscordBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleDiscordBot.dll"]
