using GraphQL.Types;

namespace super_mario_iii_remake.Schema.Types;

public class Level
{
    public string Id { get; set; } = null!;
}

public sealed class LevelType : ObjectGraphType<Level>
{
    public LevelType()
    {
        Field(x => x.Id).Description("The id of the level.");
    }
}