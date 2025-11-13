using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Magnetron_PT.Data;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// ---------------------------
//  Serilog para logs estructurados
// ---------------------------
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

// ---------------------------
// Conexion desde VARIABLE DE ENTORNO (DB_CONNECTION)
// ---------------------------
// Se intenta leer la variable de entorno "DB_CONNECTION". Si no existe, usa appsettings.
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION")
                       ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MagnetronDbContext>(options =>
    options.UseSqlServer(connectionString));

// ---------------------------
// Servicios habituales
// ---------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ---------------------------
// Swagger personalizado
// ---------------------------
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Magnetron – Facturación y Productos",
        Version = "v1",
        Description = "Servicio de facturación de productos y gestión de clientes (Proyecto prueba Grupo Magnetron)."
    });
});

var app = builder.Build();

// ---------------------------
// Middlewares / Pipeline
// ---------------------------

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Magnetron – Facturación y Productos v1");
    c.RoutePrefix = "swagger"; // URL: /swagger/index.html
});

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// ---------------------------
//  Health check simple
// ---------------------------
app.MapGet("/health", () => Results.Ok("OK"));

app.Run();

