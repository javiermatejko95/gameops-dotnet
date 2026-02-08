# Stage 1: Compilation
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy .csproj files and restore dependencies
COPY ["GameOps.Api/GameOps.Api.csproj", "GameOps.Api/"]
COPY ["GameOps.Application/GameOps.Application.csproj", "GameOps.Application/"]
COPY ["GameOps.Domain/GameOps.Domain.csproj", "GameOps.Domain/"]
COPY ["GameOps.Infrastructure/GameOps.Infrastructure.csproj", "GameOps.Infrastructure/"]
COPY ["GameOps.Contracts/GameOps.Contracts.csproj", "GameOps.Contracts/"]

RUN dotnet restore "GameOps.Api/GameOps.Api.csproj"

# Copy all source code
COPY . .

# Compile the project
WORKDIR "/src/GameOps.Api"
RUN dotnet build "GameOps.Api.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
RUN dotnet publish "GameOps.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Runtime (final image)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameOps.Api.dll"]
