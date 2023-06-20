using RestWithASPNETUdemy.Services;
using RestWithASPNETUdemy.Services.Interfaces;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

DependencyInjectionBuilder(builder);

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   // app.UseSwagger();
   // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void DependencyInjectionBuilder(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IPersonService, PersonService>();
}