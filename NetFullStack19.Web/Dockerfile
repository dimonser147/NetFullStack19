FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV Test 1

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["NetFullStack19.Web/NetFullStack19.Web.csproj", "NetFullStack19.Web/"]
RUN dotnet restore "NetFullStack19.Web/NetFullStack19.Web.csproj"
COPY . .
WORKDIR "/src/NetFullStack19.Web"
ENV Test 2
RUN dotnet build "NetFullStack19.Web.csproj" -c Release -o /app

FROM build AS publish
ENV Test 3
RUN dotnet publish "NetFullStack19.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV Test 4
ENTRYPOINT ["dotnet", "NetFullStack19.Web.dll"]

ENV Test 5
