FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["SipIt.api/SipIt.api.csproj", "SipIt.api/"]
COPY ["SipIt.api/SipIt.api.csproj", "SipIt.api/"]
RUN dotnet restore "SipIt.api/SipIt.api.csproj"
COPY . .
WORKDIR "/src/SipIt.api"
RUN dotnet build "SipIt.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SipIt.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD dotnet "SipIt.api.dll"