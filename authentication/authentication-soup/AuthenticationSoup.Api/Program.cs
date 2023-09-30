using System.Text;
using AuthenticationSoup.Api.Repositories.Contexts;
using AuthenticationSoup.Api.Repositories.Implementations;
using AuthenticationSoup.Api.Repositories.Interfaces;
using AuthenticationSoup.Api.Services.Implementations;
using AuthenticationSoup.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICookieService, CookieService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddDbContext<AuthenticationDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("AuthenticationDbConnectionString"),
        b => b.MigrationsAssembly("AuthenticationSoup.Api")
    )
);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/cookies/login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration.GetValue<string>("TokenAuthentication:Issuer"),
            ValidAudience = builder.Configuration.GetValue<string>("TokenAuthentication:Issuer"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("TokenAuthentication:SigningKey") ?? ""))
        };
    });

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
