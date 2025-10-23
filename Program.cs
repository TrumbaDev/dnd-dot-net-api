using DNDApi.Api.v1.Contracts.Enumers;
using DNDApi.Api.v1.Contracts.Hero;
using DNDApi.Api.v1.Contracts.Items;
using DNDApi.Api.v1.Contracts.Spells;
using DNDApi.Api.v1.Contracts.User;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.Middleware;
using DNDApi.Api.v1.Models.Entities;
using DNDApi.Api.v1.Repository.Enumers;
using DNDApi.Api.v1.Repository.Hero;
using DNDApi.Api.v1.Repository.Items;
using DNDApi.Api.v1.Repository.Spells;
using DNDApi.Api.v1.Repository.User;
using DNDApi.Api.v1.Services;
using DNDApi.Api.v1.Services.Hero;
using DNDApi.Api.v1.Services.Items;
using DNDApi.Api.v1.Services.Spells;
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
builder.Services.AddDbContext<SpellsDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEnumersRepository, EnumersRepository>();
builder.Services.AddScoped<IItemsRepository, ItemsRepository>();
builder.Services.AddScoped<IHeroRepository, HeroRepository>();
builder.Services.AddScoped<ISpellsRepository, SpellsRepository>();
builder.Services.AddScoped<IHeroService, HeroService>();
builder.Services.AddScoped<ItemsService>();
builder.Services.AddScoped<SpellsService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<IPasswordHasher<UserEntity>, BCryptPasswordHasher>();

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
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
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

    var SpellsDbContext = scope.ServiceProvider.GetRequiredService<SpellsDbContext>();
    SpellsDbContext.Database.EnsureCreated();
}

app.Run();
