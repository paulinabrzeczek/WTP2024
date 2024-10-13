using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WTP2024.DAL;
using WTP2024.DAL.Configuration.Settings;
using WTP2024.Repository.User;
using WTP2024.Services.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/User/LoginUser";
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

//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.Listen(System.Net.IPAddress.Parse("192.168.137.5"), 7131); // Nas³uchuj na adresie IP i porcie
//    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(5);  // Keep-alive timeout of 5 minutes
//    options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(5);  // Timeout for headers
//    options.Limits.MaxRequestBodySize = 104857600;  // 100 MB max request body size
//});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
