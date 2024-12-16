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

// Configuraci�n de la aplicaci�n
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
