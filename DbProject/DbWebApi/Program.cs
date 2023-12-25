using DbWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

try 
{
    builder.Services.AddDbContext<AddDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
    Console.WriteLine("Sucessful connection to database");
}
catch(Exception ex)
{
    Console.WriteLine($"The Error in connection to server: {ex.Message}");
}

builder.Services.AddScoped<ISqlScriptExecutor, SqlScriptExecutor>();
builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
builder.Services.AddScoped<IPatientRepo, PatientRepo>();
builder.Services.AddScoped<ITreatmentRepo, TreatmentRepo>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/*
using (var scope = app.Services.CreateScope())
        {

            var services = scope.ServiceProvider;
            try
            {
                var scriptExecutor = services.GetRequiredService<ISqlScriptExecutor>();
                // Жесткое задание пути к файлу скрипта
                string scriptFilePath = "../Scripts/init.sql";
                scriptExecutor.ExecuteScriptFromFile(scriptFilePath);
                Console.WriteLine("Script executed successfully.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Script file not found: {ex.FileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing script: {ex.Message}");
            }
        }
*/

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
