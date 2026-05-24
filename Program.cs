using DivicesSesorApi.Data;
using DivicesSesorApi.Repositories;
using DivicesSesorApi.Services;

//PostgreSQL normalmente usa:snake_case Y Dapper necesita ayuda para mapear
Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IDbConnectionFactory, DataBaseConnection>();

builder.Services.AddScoped<TemperatureSensorRepository>();

builder.Services.AddScoped<TemperatureSensorService>();

builder.Services.AddControllers();
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
