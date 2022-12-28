using AutoMapper;
using GeekShopping.ProductAPI.ApplicationContexts;
using GeekShopping.ProductAPI.Config;
using GeekShopping.ProductAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

#region Builder
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<APIDbContext>(
    options => options.UseSqlServer(connectionString));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShopping" });
});
#endregion

#region APP
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
#endregion