using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stripe;
using System;
using Tilmeldingssystem.AppDbcontext;
using Tilmeldingssystem.Interfaces;
using Tilmeldingssystem.Models.Pay;
using Tilmeldingssystem.Repository;
using Tilmeldingssystem.Services;
using Tilmeldingssystem.TicketSystem;

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Adds MVC controllers to the service collection.
/// </summary>
builder.Services.AddControllers();

/// <summary>
/// Configures Stripe settings from the application configuration.
/// </summary>
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

/// <summary>
/// Adds Swagger/OpenAPI services for API documentation.
/// </summary>
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// <summary>
/// Registers StripeClient as a singleton using the configured Stripe secret key.
/// </summary>
builder.Services.AddSingleton<IStripeClient>(sp =>
{
    var stripeSettings = sp.GetRequiredService<IOptions<StripeSettings>>().Value;
    return new StripeClient(stripeSettings.SecretKey);
});

/// <summary>
/// Selects the database connection string based on environment (Development or Production).
/// </summary>
var env = builder.Environment.EnvironmentName;
var connectionString = builder.Configuration.GetConnectionString(
    env == "Development" ? "DefaultConnection" : "support"
);

/// <summary>
/// Registers TilmeldingsDbContext using SQL Server with retry on failure enabled.
/// </summary>
builder.Services.AddDbContext<TilmeldingsDbContext>(options =>
    options.UseSqlServer(connectionString,
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()
    ));

/// <summary>
/// Configures CORS to allow any origin, header, and method.
/// </summary>
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

/// <summary>
/// Registers repositories with scoped lifetime for dependency injection.
/// </summary>
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IClubRepository, ClubRepository>();

/// <summary>
/// Registers services with scoped lifetime for dependency injection.
/// </summary>
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<ITicketService, TicketService>();

/// <summary>
/// Registers the LoginDBContext for Identity authentication and configures Identity services.
/// </summary>
builder.Services.AddDbContext<LoginDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Login")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<LoginDBContext>()
    .AddDefaultTokenProviders();

/// <summary>
/// Adds authorization services.
/// </summary>
builder.Services.AddAuthorization();

var app = builder.Build();

/// <summary>
/// Applies pending migrations to the application and Identity databases at startup.
/// </summary>
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TilmeldingsDbContext>();
    dbContext.Database.Migrate();

    var loginContext = scope.ServiceProvider.GetRequiredService<LoginDBContext>();
    loginContext.Database.Migrate();
}

/// <summary>
/// Enables Swagger and Swagger UI middleware in development environment.
/// </summary>
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/// <summary>
/// Adds middleware to redirect HTTP requests to HTTPS.
/// </summary>
app.UseHttpsRedirection();

/// <summary>
/// Enables the configured CORS policy globally.
/// </summary>
app.UseCors("AllowAll");

/// <summary>
/// Adds authorization middleware to the request pipeline.
/// </summary>
app.UseAuthorization();

/// <summary>
/// Maps controller endpoints for incoming requests.
/// </summary>
app.MapControllers();

/// <summary>
/// Enables serving of static files from the wwwroot folder.
/// </summary>
app.UseStaticFiles();

/// <summary>
/// Runs the application.
/// </summary>
app.Run();
