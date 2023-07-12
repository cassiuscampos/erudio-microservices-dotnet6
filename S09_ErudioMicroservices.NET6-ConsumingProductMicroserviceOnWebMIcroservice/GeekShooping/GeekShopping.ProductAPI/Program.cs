using AutoMapper;
using GeekShopping.ProductAPI.Config;
using GeekShopping.ProductAPI.Model.Context;
using GeekShopping.ProductAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//CONEXAO
var connection = builder.Configuration["MySQlConnection:MySQlConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options.
    UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 5))));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShopping.ProductAPI", Version = "v1" });
});

// Mappings
AddMappings(builder.Services);

// Repositories
AddRepositories(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();


void AddRepositories(IServiceCollection service)
{
    service.AddScoped<IProductRepository, ProductRepository>();
}

void AddMappings(IServiceCollection services)
{
    IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
    services.AddSingleton(mapper);
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
}