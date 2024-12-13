using Microsoft.Data.Sqlite;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IChoferRepository , ChoferRepository>();
var connectionString = builder.Configuration.GetConnectionString("sqliteConnecion")!.ToString();
builder.Services.AddSingleton<string>(connectionString);


// Inicializa SQLite
SQLitePCL.Batteries.Init();

// Add services to the container.
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
