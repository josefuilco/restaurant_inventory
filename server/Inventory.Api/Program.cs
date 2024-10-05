using System.Text.Json;
using Inventory.Api.Database;
using Inventory.Api.Module.Auth.Adapter.ExternalService;
using Inventory.Api.Module.Auth.Adapter.Repository;
using Inventory.Api.Module.Auth.Application.Port.Service;
using Inventory.Api.Module.Auth.Application.Service;
using Inventory.Api.Module.Auth.Domain.Port.ExternalService;
using Inventory.Api.Module.Auth.Domain.Port.Repository;
using Inventory.Api.Module.Foods.Adapter.Repository;
using Inventory.Api.Module.Foods.Application.Port.Service;
using Inventory.Api.Module.Foods.Application.Service;
using Inventory.Api.Module.Foods.Domain.Port.Repository;
using Inventory.Api.Module.History.Adapter.Repository;
using Inventory.Api.Module.History.Application.Port.Service;
using Inventory.Api.Module.History.Application.Service;
using Inventory.Api.Module.History.Domain.Port.Repository;
using Inventory.Api.Module.Inventory.Adapter.Repository;
using Inventory.Api.Module.Inventory.Application.Port.Service;
using Inventory.Api.Module.Inventory.Application.Service;
using Inventory.Api.Module.Inventory.Domain.Port.Repository;

var corsPolicy = "_MyAllowSpecificOrigin";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    options.AddPolicy(corsPolicy, policy =>
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Dependency Injection
builder.Services.AddSingleton<SqlServerDatabase>();
// Dependency Auth Module
builder.Services.AddSingleton<IToken, JwtToken>();
builder.Services.AddScoped<IUserRepository, SqlServerUserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
// Dependency Foods Module
builder.Services.AddScoped<IFoodRepository, SqlServerFoodRepository>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IFoodTypeService, FoodTypeService>();
// Dependency Inventory Module
builder.Services.AddScoped<IProductRepository, SqlServerProductRepository>();
builder.Services.AddScoped<IProviderRepository, SqlServerProviderRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProviderService, ProviderService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUnitMeasureService, UnitMeasureService>();
// Dependency History Module
builder.Services.AddScoped<IHistoryRepository, SqlServerHistoryRepository>();
builder.Services.AddScoped<IHistoryService, HistoryService>();
builder.Services.AddScoped<IOperationService, OperationService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); Use when have SSL Certificated
app.UseCors(corsPolicy);
app.MapControllers();

app.Run();