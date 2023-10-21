using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var auth0Section = builder.Configuration.GetSection("Auth0");
    options.Authority = auth0Section.GetValue<string>("Authority");
    options.Audience = auth0Section.GetValue<string>("Audience");
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("read:employees", policy =>
        policy.RequireClaim("permissions", "read:employees"));

    options.AddPolicy("write:employees", policy =>
        policy.RequireClaim("permissions", "write:employees"));
});


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
