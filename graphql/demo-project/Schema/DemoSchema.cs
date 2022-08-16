using GraphQL.Instrumentation;
using demo_project.Mutations;
using demo_project.Queries;
using demo_project.Schema.Types;

namespace demo_project.Schema;

public class DemoSchema : GraphQL.Types.Schema
{
    public DemoSchema(IServiceProvider provider)
        : base(provider)
    {
        Query = (DemoQuery)provider.GetService(typeof(DemoQuery))! ?? throw new InvalidOperationException();
        Mutation = (DemoMutations) provider.GetService(typeof(DemoMutations))! ?? throw new InvalidOperationException();

        FieldMiddleware.Use(new InstrumentFieldsMiddleware());
    }
}