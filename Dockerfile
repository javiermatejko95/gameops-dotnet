# Etapa 1: Compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos .csproj y restaurar dependencias
COPY ["GameOps.Api/GameOps.Api.csproj", "GameOps.Api/"]
COPY ["GameOps.Application/GameOps.Application.csproj", "GameOps.Application/"]
COPY ["GameOps.Domain/GameOps.Domain.csproj", "GameOps.Domain/"]
COPY ["GameOps.Infrastructure/GameOps.Infrastructure.csproj", "GameOps.Infrastructure/"]

RUN dotnet restore "GameOps.Api/GameOps.Api.csproj"

# Copiar todo el código fuente
COPY . .

# Compilar el proyecto
WORKDIR "/src/GameOps.Api"
RUN dotnet build "GameOps.Api.csproj" -c Release -o /app/build

# Etapa 2: Publicación
FROM build AS publish
RUN dotnet publish "GameOps.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 3: Runtime (imagen final)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameOps.Api.dll"]
