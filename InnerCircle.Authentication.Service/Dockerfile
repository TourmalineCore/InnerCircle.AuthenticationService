#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["InnerCircle.Authentication.Service/InnerCircle.Authentication.Service.csproj", "InnerCircle.Authentication.Service/"]
COPY ["Data/Data.csproj", "Data/"]
RUN dotnet restore "InnerCircle.Authentication.Service/InnerCircle.Authentication.Service.csproj"
COPY . .
WORKDIR "/src/InnerCircle.Authentication.Service"
RUN dotnet build "InnerCircle.Authentication.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InnerCircle.Authentication.Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InnerCircle.Authentication.Service.dll"]