using DotNetEnv;
using Microsoft.AspNetCore.Components.RenderTree;
using NewApi.Repositories;
using NewApi.Services;
using Npgsql;

Env.Load();

var host = Environment.GetEnvironmentVariable("Host");
var database = Environment.GetEnvironmentVariable("Database");
var username = Environment.GetEnvironmentVariable("Username");
var password = Environment.GetEnvironmentVariable("Password");
var port =  Environment.GetEnvironmentVariable("port");


var connectionString =
    $"Host={host};Port={port};Database={database};Username={username};Password={password};SSL Mode=Require";
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddSingleton(

     NpgsqlDataSource.Create(connectionString!)
);

builder.Services.AddOpenApi();

// // for database setup
// builder.Services.AddScoped<NpgsqlDataSource>(_ =>


// {
//     return NpgsqlDataSource.Create(connectionString!);
    
// });


builder.Services.AddScoped<IProductService,ProductServices>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddControllers();



var app = builder.Build();

app.MapControllers();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();// middleware



app.Run();


























// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
