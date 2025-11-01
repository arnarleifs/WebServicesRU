using StargateUniversity.PaymentGateway.Commons.Clients;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<PaymentProviderClient>(opt =>
{
    var configSection = builder.Configuration.GetSection("PaymentProvider");

    opt.BaseAddress = new Uri(configSection.GetValue<string>("BaseUrl") ?? "");
    opt.DefaultRequestHeaders.Add("X-Api-Key", configSection.GetValue<string>("ApiKey"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
    {
        policy.WithOrigins(builder.Configuration.GetValue<string>("Cors:ClientUrl") ?? "")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
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