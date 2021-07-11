FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["backend/junior-analyst/JuniorAnalyst.Application.csproj", "backend/junior-analyst/"]
RUN dotnet restore "backend/junior-analyst/JuniorAnalyst.Application.csproj"
COPY . .
WORKDIR "/src/backend/junior-analyst"
RUN dotnet build "JuniorAnalyst.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JuniorAnalyst.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JuniorAnalyst.Application.dll"]