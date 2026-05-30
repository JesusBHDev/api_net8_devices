using DivicesSesorApi.Data;
using DivicesSesorApi.Repositories;
using DivicesSesorApi.Services;

//PostgreSQL normalmente usa:snake_case Y Dapper necesita ayuda para mapear
//como en la  bd estan los nombes sensor_name y en c# SensorName pues es para que coincidan
//"Oye Dapper...si encuentras:sensor_name entiende que probablemente significa: SensorName"
Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true; 

var builder = WebApplication.CreateBuilder(args);

//Dependency Injection (DI) Es cuando .NET crea objetos automáticamente por ti.
// se agrega inyecccion de dependencias, esta es la de la bd Esto es Dependency Injection
/*"Oye .NET...i alguien pide:IDbConnectionFactory entrégale: DataBaseConnection" */
//aqui desclopamos repository NO conoce:DataBaseConnection solo conoce: IDbConnectionFactory
builder.Services.AddSingleton<IDbConnectionFactory, DataBaseConnection>();
//" ¿Qué significa AddSingleton? Crear UNA sola instancia en toda la aplicación"
//O sea Durante toda la vida de la API:solo existirá:1 DataBaseConnection


//Scoped Cada request HTTP obtiene uno nuevo
//se ordena a neet "Estas clases también pueden inyectarse" ya saber crear instnacias solitas
// cada request HTTP obtiene una instancia nueva
builder.Services.AddScoped<TemperatureSensorRepository>();
builder.Services.AddScoped<TemperatureSensorService>();
//Scoped Cada request HTTP obtiene uno nuevo

//Le dice a ASP.NET: "Esta aplicación usa Controllers" 
//Gracias a esto .NET empieza a buscar:[ApiController] y ControllerBase
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
