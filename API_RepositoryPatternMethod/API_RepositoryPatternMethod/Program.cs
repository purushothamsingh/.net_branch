using API_RepositoryPatternMethod.IRepository;
using API_RepositoryPatternMethod.Models;
using API_RepositoryPatternMethod.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var connectionString = builder.Configuration.GetConnectionString("Myconn");
builder.Services.AddDbContext<StudentContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IRepositoryStudent, StudentRepository>();
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
