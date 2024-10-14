using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WTP2024.DAL;
using WTP2024.DAL.Configuration.Settings;
using WTP2024.Repository.User;
using WTP2024.Services.User;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/User/LoginUser";
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireLoggedIn", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
    options.AddPolicy("AdminAccess", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("admin");
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WTP2024DbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));
//Service
builder.Services.AddScoped<IUserService, UserService>();
//Repos
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true; // Enable compression for HTTPS
});

builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(System.Net.IPAddress.Parse("192.168.137.1"), 7131); // Nas�uchuj na adresie IP i porcie
    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(5);  // Keep-alive timeout of 5 minutes
    options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(5);  // Timeout for headers
    options.Limits.MaxRequestBodySize = 104857600;  // 100 MB max request body size
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
