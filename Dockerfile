FROM microsoft/dotnet:sdk AS build-env
WORKDIR /

# Copy csproj and restore as distinct layers
COPY Twittor.Identity/*.csproj ./Twittor.Identity/
COPY Twittor.Identity.DataAccess/*.csproj ./Twittor.Identity.DataAccess/
COPY Twittor.Identity.Infrastructure/*.csproj ./Twittor.Identity.Infrastructure/
COPY Twittor.Identity.JWT/*.csproj ./Twittor.Identity.JWT/
COPY Twittor.Identity.Repository/*csproj ./Twittor.Identity.Repository/
COPY Twittor.Identity.Services/*.csproj ./Twittor.Identity.Services/

COPY ./*.sln ./
RUN dotnet restore

# Copy everything else and build
COPY Twittor.Identity/. ./Twittor.Identity
COPY Twittor.Identity.DataAccess/. ./Twittor.Identity.DataAccess
COPY Twittor.Identity.Infrastructure/. ./Twittor.Identity.Infrastructure
COPY Twittor.Identity.JWT/. ./Twittor.Identity.JWT
COPY Twittor.Identity.Repository/. ./Twittor.Identity.Repository
COPY Twittor.Identity.Services/. ./Twittor.Identity.Services
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app/Twittor.Identity
COPY --from=build-env /app/Twittor.Identity/out .
ENTRYPOINT ["dotnet", "Twittor.Identity.dll"]