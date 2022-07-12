using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using super_mario_iii_remake.Data;
using super_mario_iii_remake.Schema;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQL(qlBuilder =>
{
    qlBuilder.AddHttpMiddleware<ISchema>();
    qlBuilder.AddSystemTextJson();
    qlBuilder.AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true);
    qlBuilder.AddSchema<SMBSchema>();
    qlBuilder.AddGraphTypes(typeof(SMBSchema).Assembly);
});

builder.Services.AddSingleton<SMBData>();

var app = builder.Build();

app.UseGraphQLPlayground();
app.UseGraphQL<ISchema>();
app.MapGet("/", context =>
{
    context.Response.Redirect("/ui/playground");
    return Task.CompletedTask;
});

app.Run();
