#This is a Linux container docker file

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Actio.Services.Activities/Actio.Services.Activities.csproj", "src/Actio.Services.Activities/"]
COPY ["src/Actio.Common/Actio.Common.csproj", "src/Actio.Common/"]
RUN dotnet restore "src/Actio.Services.Activities/Actio.Services.Activities.csproj"
COPY . .
WORKDIR "/src/src/Actio.Services.Activities"
RUN dotnet build "Actio.Services.Activities.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Actio.Services.Activities.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_URLS http://*:5050
ENV ASPNETCORE_ENVIRONMENT docker
ENTRYPOINT ["dotnet", "Actio.Services.Activities.dll"]