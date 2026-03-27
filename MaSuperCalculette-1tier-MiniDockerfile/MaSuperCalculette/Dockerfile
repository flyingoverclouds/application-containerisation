# Minimal Dockerfile for the c# MaSuperCalculette (1 tiers)
FROM mcr.microsoft.com/dotnet/sdk:10.0 

# on se place dans le dossier /src (dans l'image)
WORKDIR "/src"
COPY ["MaSuperCalculette.csproj", "."]
RUN dotnet restore

# on copie les sources de l'application (dossier courant contenant le .csproj) dans le workdir courant de l'image (/src)
COPY "." "."   

# on execute la sequence de compilation/publication de notre application
WORKDIR "/src/."
RUN dotnet restore
RUN dotnet build -c Release
RUN dotnet publish -c Release

# l'application est à l'écoute sur le port 8080
EXPOSE 8080

#on se positionne dans le contenant wwwroot
WORKDIR "/src/bin/Release/net10.0/publish/"
#on demarre l'application
ENTRYPOINT ["dotnet","MaSuperCalculette.dll"]






