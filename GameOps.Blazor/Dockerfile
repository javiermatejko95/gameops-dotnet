# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["GameOps.Blazor/GameOps.Blazor.csproj", "GameOps.Blazor/"]
COPY ["GameOps.Contracts/GameOps.Contracts.csproj", "GameOps.Contracts/"]

RUN dotnet restore "GameOps.Blazor/GameOps.Blazor.csproj"

COPY . .

WORKDIR /src/GameOps.Blazor
RUN dotnet publish -c Release -o /app

# Runtime
FROM nginx:alpine
COPY GameOps.Blazor/nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=build /app/wwwroot /usr/share/nginx/html
