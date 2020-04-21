#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SipIt.orders/SipIt.orders.csproj", "SipIt.orders/"]
COPY ["SipIt.types/SipIt.types.csproj", "SipIt.types/"]
RUN dotnet restore "SipIt.orders/SipIt.orders.csproj"
COPY . .
WORKDIR "/src/SipIt.orders"
RUN dotnet build "SipIt.orders.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SipIt.orders.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SipIt.orders.dll"]