FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
RUN ["apt-get", "update"]
RUN ["apt-get", "-y", "install", "libgdiplus"]
RUN ["apt-get", "-y", "install", "xvfb", "libfontconfig", "wkhtmltopdf"]
RUN ["apt-get", "-y", "install", "libc6-dev"]
RUN ["apt-get", "-y", "install", "openssl"]
RUN ["apt-get", "-y", "install", "libssl1.0-dev"]

WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["IronPdf/IronPdf.csproj", "IronPdf/"]
RUN dotnet restore "IronPdf/IronPdf.csproj"
COPY . .
WORKDIR "/src/IronPdf"
RUN dotnet build "IronPdf.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "IronPdf.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IronPdf.dll"]