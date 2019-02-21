FROM microsoft/dotnet:sdk AS build-env
WORKDIR /

# Copy csproj and restore as distinct layers
COPY Identity.Web/*.csproj ./Identity.Web/
COPY Identity.DataAccess/*.csproj ./Identity.DataAccess/
COPY Identity.Infrastructure/*.csproj ./Identity.Infrastructure/
COPY Identity.JWT/*.csproj ./Identity.JWT/
COPY Identity.Repository/*csproj ./Identity.Repository/
COPY Identity.Services/*.csproj ./Identity.Services/

COPY ./*.sln ./
RUN dotnet restore

# Copy everything else and build
COPY Identity.Web/. ./Identity.Web
COPY Identity.DataAccess/. ./Identity.DataAccess
COPY Identity.Infrastructure/. ./Identity.Infrastructure
COPY Identity.JWT/. ./Identity.JWT
COPY Identity.Repository/. ./Identity.Repository
COPY Identity.Services/. ./Identity.Services
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app/Identity
COPY --from=build-env /app/Identity/out .
ENTRYPOINT ["dotnet", "Identity.dll"]