FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
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