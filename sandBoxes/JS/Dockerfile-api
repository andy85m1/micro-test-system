#This is a Linux container docker file

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Actio.Api/Actio.Api.csproj", "src/Actio.Api/"]
COPY ["src/Actio.Services.Activities/Actio.Services.Activities.csproj", "src/Actio.Services.Activities/"]
COPY ["src/Actio.Common/Actio.Common.csproj", "src/Actio.Common/"]
COPY ["src/Actio.Services.Identity/Actio.Services.Identity.csproj", "src/Actio.Services.Identity/"]
RUN dotnet restore "src/Actio.Api/Actio.Api.csproj"
COPY . .
WORKDIR "/src/src/Actio.Api"
RUN dotnet build "Actio.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Actio.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT docker
ENTRYPOINT ["dotnet", "Actio.Api.dll"]