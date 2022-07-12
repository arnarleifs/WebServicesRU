using GraphQL.Types;

namespace super_mario_iii_remake.Schema.Types;

public class Character
{
    public string Id { get; set; } = null!;
    public string? Name { get; set; }
    public string? Description { get; set; }
}

public sealed class CharacterType : ObjectGraphType<Character>
{
    public CharacterType()
    {
        Field(x => x.Id).Description("The id of the character.");
        Field(x => x.Name).Description("The name of the character.");
        Field(x => x.Description).Description("The description of the character");
    }
}