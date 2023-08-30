using demo_project.Data;
using demo_project.Schema;
using GraphQL;
using GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQL(qlBuilder =>
{
    qlBuilder.AddSystemTextJson();
    qlBuilder.AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true);
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
