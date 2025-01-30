# .NET SDK'yı kullanarak build işlemi yapılacak
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Proje dosyalarını kopyala ve restore işlemi yap
COPY *.csproj .
RUN dotnet restore

# Tüm dosyaları kopyala ve publish işlemi yap
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Runtime image'ini kullanarak uygulamayı çalıştır
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebFinalProject.dll"]