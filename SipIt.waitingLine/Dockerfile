#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SipIt.waitingLine/SipIt.waitingLine.csproj", "SipIt.waitingLine/"]
COPY ["SipIt.types/SipIt.types.csproj", "SipIt.types/"]
RUN dotnet restore "SipIt.waitingLine/SipIt.waitingLine.csproj"
COPY . .
WORKDIR "/src/SipIt.waitingLine"
RUN dotnet build "SipIt.waitingLine.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SipIt.waitingLine.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SipIt.waitingLine.dll"]