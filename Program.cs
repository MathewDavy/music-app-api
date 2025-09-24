using System;
using Api.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
// builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();

// Disable CORS since angular will be running on port 4200 and the service on port 5258.
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// // --- 1. Read configuration and build connection string ---
// // var config = new ConfigurationBuilder()
// //     .SetBasePath(Directory.GetCurrentDirectory())
// //     .AddJsonFile("appsettings.json")
// //     .Build();
// // var connectionString = config.GetConnectionString("DefaultConnection");
// // await using var conn = new NpgsqlConnection(connectionString);

// try
// {
//     await conn.OpenAsync();
//     Console.WriteLine("Connection established");
//     await using (var cmd = new NpgsqlCommand())
//     {
//         cmd.Connection = conn;
//         // cmd.CommandText = "DROP TABLE IF EXISTS books;";
//         // await cmd.ExecuteNonQueryAsync();
//         // Console.WriteLine("Finished dropping table (if it existed).");
//         // cmd.CommandText = @"
//         //     CREATE TABLE grid (
//         //         id SERIAL PRIMARY KEY,
//         //         gridId INT,
//         //         gridColumn INT,
//         //         duration VARCHAR(255),
//         //         notes TEXT[]
//         //     );";
//         // await cmd.ExecuteNonQueryAsync();
//         // Console.WriteLine("Finished creating table.");

//         cmd.CommandText = "INSERT INTO books (title, author, publication_year, in_stock) VALUES (@t1, @a1, @y1, @s1);";
//         cmd.Parameters.AddWithValue("t1", "The Catcher in the Rye");
//         cmd.Parameters.AddWithValue("a1", "J.D. Salinger");
//         cmd.Parameters.AddWithValue("y1", 1951);
//         cmd.Parameters.AddWithValue("s1", true);
//         await cmd.ExecuteNonQueryAsync();
//         Console.WriteLine("Inserted a single book.");
//         cmd.Parameters.Clear();
//     }
// }
// catch (Exception e)
// {
//     Console.WriteLine("Connection failed");
//     Console.WriteLine(e.Message);
// }

app.Run();