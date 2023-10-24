using API_SAT_1.DAL;
using API_SAT_1.Domain.Interfaces;
using API_SAT_1.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Esta linea crea el contexto de la BD a la hora de correr la API
//Funciones anonimas (x => x...) Arrow Functions - Lamda Functions
builder.Services.AddDbContext<DataBaseContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ICountryService, CountryService>();
//Por cada nuevo servicio/interface que yo creo en mi API debo agregar aquí esa nueva dependencia

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
