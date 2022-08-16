using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using demo_project.Data;
using demo_project.Schema;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQL(qlBuilder =>
{
    qlBuilder.AddHttpMiddleware<ISchema>();
    qlBuilder.AddSystemTextJson();
    qlBuilder.AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true);
    qlBuilder.AddSchema<DemoSchema>();
    qlBuilder.AddGraphTypes(typeof(DemoSchema).Assembly);
});

builder.Services.AddSingleton<DemoData>();

var app = builder.Build();

app.UseGraphQLPlayground();
app.UseGraphQL<ISchema>();
app.MapGet("/", context =>
{
    context.Response.Redirect("/ui/playground");
    return Task.CompletedTask;
});

app.Run();
