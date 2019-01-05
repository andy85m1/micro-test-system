#This is a Linux container docker file

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Actio.Services.Identity/Actio.Services.Identity.csproj", "src/Actio.Services.Identity/"]
COPY ["src/Actio.Common/Actio.Common.csproj", "src/Actio.Common/"]
RUN dotnet restore "src/Actio.Services.Identity/Actio.Services.Identity.csproj"
COPY . .
WORKDIR "/src/src/Actio.Services.Identity"
RUN dotnet build "Actio.Services.Identity.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Actio.Services.Identity.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_URLS http://*:5051
ENV ASPNETCORE_ENVIRONMENT docker
ENTRYPOINT ["dotnet", "Actio.Services.Identity.dll"]