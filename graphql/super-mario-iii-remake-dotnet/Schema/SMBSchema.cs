using GraphQL.Instrumentation;
using super_mario_iii_remake.Mutations;
using super_mario_iii_remake.Queries;
using super_mario_iii_remake.Schema.Interfaces;
using super_mario_iii_remake.Schema.Types;

namespace super_mario_iii_remake.Schema;

public class SMBSchema : GraphQL.Types.Schema
{
    public SMBSchema(IServiceProvider provider)
        : base(provider)
    {
        Query = (SMBQuery)provider.GetService(typeof(SMBQuery))! ?? throw new InvalidOperationException();
        Mutation = (SMBMutations) provider.GetService(typeof(SMBMutations))! ?? throw new InvalidOperationException();

        // Register types so they are visible in the schema
        RegisterType(typeof(CommonEnemyType));
        RegisterType(typeof(BossEnemyType));

        FieldMiddleware.Use(new InstrumentFieldsMiddleware());
    }
}