using DNDApi.Api.v1.Contracts.Hero;
using DNDApi.Api.v1.Contracts.User;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.Models.Entities;
using DNDApi.Api.v1.Services;
using DNDApi.Api.v1.Services.Enumers;
using DNDApi.Api.v1.Services.Hero;
using DNDApi.Api.v1.Services.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // например, в Dev отключаем policy
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddOpenApi();

builder.Services.AddDbContext<UsersDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ItemsDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<EnumersDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<HeroDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHeroService, HeroService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<IPasswordHasher<UserEntity>, BCryptPasswordHasher>();
builder.Services.AddScoped<EnumerService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
}

app.UseHttpsRedirection();
app.MapControllers();

// Выводим все роуты для дебага
foreach (var endpoint in app.Services.GetRequiredService<EndpointDataSource>().Endpoints)
{
    Console.WriteLine($"[ROUTE] {endpoint.DisplayName}");
}

// Автоматически создаём БД
using (var scope = app.Services.CreateScope())
{
    var usersDbContext = scope.ServiceProvider.GetRequiredService<UsersDbContext>();
    usersDbContext.Database.EnsureCreated();

    var itemsDbContext = scope.ServiceProvider.GetRequiredService<ItemsDbContext>();
    itemsDbContext.Database.EnsureCreated();

    var enumersDbContext = scope.ServiceProvider.GetRequiredService<EnumersDbContext>();
    enumersDbContext.Database.EnsureCreated();

    var heroDbContext = scope.ServiceProvider.GetRequiredService<HeroDbContext>();
    heroDbContext.Database.EnsureCreated();
}

app.Run();
