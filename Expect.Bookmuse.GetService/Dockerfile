#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Expect.Bookmuse.GetService/Expect.Bookmuse.GetService.csproj", "Expect.Bookmuse.GetService/"]
RUN dotnet restore "Expect.Bookmuse.GetService/Expect.Bookmuse.GetService.csproj"
COPY . .
WORKDIR "/src/Expect.Bookmuse.GetService"
RUN dotnet build "Expect.Bookmuse.GetService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Expect.Bookmuse.GetService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Expect.Bookmuse.GetService.dll"]