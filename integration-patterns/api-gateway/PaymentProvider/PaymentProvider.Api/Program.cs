using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PaymentProvider.DataAccessLayer.Contexts;
using PaymentProvider.DataAccessLayer.Services;
using PaymentProvider.DataAccessLayer.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ApiKeyValidatorService>();
builder.Services.AddTransient<PaymentLinksService>();
builder.Services.AddTransient<WebhookService>();
builder.Services.AddSingleton<HmacSignatureUtility>(_ =>
    new HmacSignatureUtility(builder.Configuration.GetValue<string>("HmacKey") ?? ""));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
    {
        policy.WithOrigins(builder.Configuration.GetValue<string>("Cors:Ui") ?? "")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<PaymentProviderDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PaymentProviderDb"),
        optionsBuilder => optionsBuilder.MigrationsAssembly("PaymentProvider.Api"));
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowBlazor");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();