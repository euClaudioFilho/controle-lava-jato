using EstacionamentoInfra.DAOs;
using MySql.Data.MySqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:7146") 
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddTransient<IDbConnection>(sp => new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<ICarroDAO, CarroDAO>();
builder.Services.AddTransient<IMovimentacaoDAO, MovimentacaoDAO>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
