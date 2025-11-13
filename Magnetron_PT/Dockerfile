# Etapa 1: Compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Magnetron_PT.csproj"
RUN dotnet publish "Magnetron_PT.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Configurar el puerto correcto
EXPOSE 5167
ENV ASPNETCORE_URLS=http://+:5167

ENTRYPOINT ["dotnet", "Magnetron_PT.dll"]
