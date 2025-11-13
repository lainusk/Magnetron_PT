#  MAGNETRON PRUEBA DESARROLLADOR SENIOR

Proyecto desarrollado en **.NET 8**, **Entity Framework Core** y **SQL Server / Azure SQL**, como parte de la **Prueba Técnica para Grupo Magnetron**.

##  Estructura del proyecto

Magnetron_PT/
├── Controllers/ # Controladores de la API
├── Models/ # Entidades y relaciones
├── Data/ # Contexto de base de datos
├── Scripts/ # Scripts SQL de creación y vistas
├── Dockerfile # Imagen para despliegue (multi-stage)
├── README.md # Documentación general
└── appsettings.json # Configuración local

## Tecnologías utilizadas

- **C# / .NET 8**
- **Entity Framework Core**
- **SQL Server / Azure SQL**
- **Swagger UI**
- **Docker (multi-stage build)**
- **Serilog (logs estructurados)**
- **Git / GitHub**

---

## Funcionalidades principales

- CRUD completo de **Personas**, **Productos** y **Facturas**.
- Endpoints adicionales para consultar **vistas SQL**:
- Total facturado por persona.
- Persona que compró el producto más caro.
- Productos ordenados por cantidad facturada.
- Productos por utilidad generada.
- Productos con margen de ganancia.
- Despliegue rápido mediante **contenedor Docker**.
- Logs estructurados con **Serilog**.
- Código estructurado bajo principios **SOLID**.
## INSTALACION RAPIDA
### 1. Clonar el repositorio

```bash
git clone https://github.com/lainusk/Magnetro_PT
cd magnetron_pt

### 2️. Configurar la base de datos

En el archivo appsettings.json, define la conexión a tu Azure SQL o SQL Server local.

O usa variable de entorno :

-- $env:ConnectionStrings__DefaultConnection="Server=tcp:sqlserverprb004.database.windows.net;Database=MagnetronDB;User ID=usuario;Password=tu_clave;"

## 3️ Ejecutar localmente

Desde Visual Studio:

Pulsa Ctrl + F5

Abre en navegador:
-- http://localhost:5167/swagger/index.html

## 4️. Ejecutar con Docker (multi-stage optimizado)
-- Dockerfile 
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

EXPOSE 5167
ENV ASPNETCORE_URLS=http://+:5167
ENTRYPOINT ["dotnet", "Magnetron_PT.dll"]

## Construcción y ejecución
docker build -t magnetron_api .
docker run -d -p 5167:5167 magnetron_api

Luego abre en navegador:
http://localhost:5167/swagger/index.html

## PLUS APLICADOS
## PLUS 1 – Variables de entorno para conexión

El connection string puede configurarse desde una variable de entorno en lugar de appsettings.json para entornos productivos (Docker, Azure, etc.).

## PLUS 2 – Health Check

Se agregó el endpoint:

GET /health


Devuelve “OK” si la API está viva.

## PLUS 3 – Swagger personalizado

Título cambiado a:

API Magnetron – Facturación y Productos
Descripción actualizada con contexto del sistema.
## PLUS 4 – Logs estructurados (Serilog)

Configurado en Program.cs:

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
builder.Host.UseSerilog();


Permite visualizar logs con formato:

[11:11:55 INF] Request starting HTTP/1.1 GET /health
[11:11:55 INF] Request finished in 8.32ms 200 text/plain

##  PLUS 5 – Dockerfile multi-stage optimizado

Implementado para reducir el tamaño de la imagen Docker (~200 MB).
Separa compilación y ejecución, alineado con buenas prácticas DevOps.

## Ventajas de la solución

-- Despliegue rápido en cualquier entorno (local o cloud).

-- Arquitectura limpia y mantenible.

-- Logs claros y monitoreables.

-- Preparado para CI/CD (GitHub Actions, Azure Pipelines, etc.).

-- Imágenes livianas gracias al build multi-stage.

## Autora

Kelly P. Diaz Granados N. 
Desarrolladora .NET | Apasionada por arquitectura limpia, optimización y buenas prácticas DevOps.
Correo lainusk@gmail.com 
GitHub: lainusk

