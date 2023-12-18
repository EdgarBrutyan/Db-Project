using DbWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



var builder = WebApplication.CreateBuilder(args);

try 
{
    builder.Services.AddDbContext<AddDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("PlatformConnection")));
    Console.WriteLine("Sucessful connection to database");
}

catch(Exception ex)
{
    Console.WriteLine($"{ex.Message}");
}


builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
builder.Services.AddScoped<IPatientRepo, PatientRepo>();

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
