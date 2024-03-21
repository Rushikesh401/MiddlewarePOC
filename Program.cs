using Microsoft.EntityFrameworkCore;
using MiddlewarePOC.Data;
using MiddlewarePOC.Middlewares;
using MiddlewarePOC;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuring EFCore to use PostgresSQL data with connection  string name "PersonDbManager" from application configuration
builder.Services.AddDbContext<DataContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("PersonDbManager")));

builder.Services.AddApplicationServices();


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

app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseMiddleware<ResponseTimeMiddleware>();    

app.Run();
