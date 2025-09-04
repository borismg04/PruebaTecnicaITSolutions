using DataBase;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Network Device Management API",
        Version = "v1",
        Description = "API REST para la gestión de dispositivos de red (switches, routers, firewalls, servidores)",
        Contact = new OpenApiContact
        {
            Name = "Boris Mg",
            Url = new Uri("https://github.com/borismg04")
        }
    });

    // Incluir archivo de documentación XML
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Inyección de dependencias
builder.Services.AddScoped<IDevicesServices, DevicesServices>();
builder.Services.AddDbContext<DataBaseInput>(options => options.UseInMemoryDatabase("DataBaseDev"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Network Device Management API v1");
        c.RoutePrefix = string.Empty; // Para que Swagger esté en la raíz
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
