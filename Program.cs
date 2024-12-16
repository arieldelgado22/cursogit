using Microsoft.AspNetCore.Mvc;
using WebApiUsuario.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpsRedirection(options =>
{
   options.HttpsPort = 5001;
});

// Agregar servicios al contenedor
builder.Services.AddControllers();

var app = builder.Build();

// Configuración de la aplicación
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
