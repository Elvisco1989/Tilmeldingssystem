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

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<TilmeldingsDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IStripeClient>(sp =>
{
    var stripeSettings = sp.GetRequiredService<IOptions<StripeSettings>>().Value;
    return new StripeClient(stripeSettings.SecretKey);
});

//builder.Services.AddDbContext<TilmeldingsDbContext>(options =>
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("support"),
//        sqlserveroptions => sqlserveroptions.EnableRetryOnFailure()
//    ));

var env = builder.Environment.EnvironmentName;

var connectionString = builder.Configuration.GetConnectionString(
    env == "Development" ? "DefaultConnection" : "support"
);

builder.Services.AddDbContext<TilmeldingsDbContext>(options =>
    options.UseSqlServer(connectionString,
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()
    ));




// Register StripeClient as a singleton
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(policy =>
//    {
//        policy
//            .AllowAnyOrigin()       // Allows all origins
//            .AllowAnyHeader()
//            .AllowAnyMethod();
//    });
//});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});








// Register repositories
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IClubRepository, ClubRepository>();
// Register services
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<ITicketService, TicketService>();


builder.Services.AddDbContext<LoginDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Login")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<LoginDBContext>()




.AddEntityFrameworkStores<LoginDBContext>()
.AddDefaultTokenProviders();
builder.Services.AddAuthorization();





var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TilmeldingsDbContext>();
    dbContext.Database.Migrate();

    var loginContext = scope.ServiceProvider.GetRequiredService<LoginDBContext>();
    loginContext.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(); // Enable CORS


app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles(); // To serve wwwroot files


app.Run();
