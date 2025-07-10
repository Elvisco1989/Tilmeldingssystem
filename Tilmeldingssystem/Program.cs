using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stripe;
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
builder.Services.AddDbContext<TilmeldingsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IStripeClient>(sp =>
{
    var stripeSettings = sp.GetRequiredService<IOptions<StripeSettings>>().Value;
    return new StripeClient(stripeSettings.SecretKey);
});



// Register StripeClient as a singleton
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()       // Allows all origins
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

app.Run();
