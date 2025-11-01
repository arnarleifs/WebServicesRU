using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StargateUniversity.PaymentGateway.UiClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var baseUrl = config["PaymentGatewayApi:BaseUrl"]
                  ?? throw new InvalidOperationException("PaymentGatewayApi:BaseUrl not configured");

    return new HttpClient { BaseAddress = new Uri(baseUrl) };
});

await builder.Build().RunAsync();