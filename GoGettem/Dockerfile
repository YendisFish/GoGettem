﻿FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
RUN apt update && apt -y install python
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GoGettem/GoGettem.csproj", "GoGettem/"]
RUN dotnet restore "GoGettem/GoGettem.csproj"
COPY . .
WORKDIR "/src/GoGettem"
RUN dotnet build "GoGettem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GoGettem.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GoGettem.dll"]
