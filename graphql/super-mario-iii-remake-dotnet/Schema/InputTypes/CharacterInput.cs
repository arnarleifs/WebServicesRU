using GraphQL.Types;

namespace super_mario_iii_remake.Schema.InputTypes;

public class CharacterInput
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}

public sealed class CharacterInputType : InputObjectGraphType<CharacterInput>
{
    public CharacterInputType()
    {
        Name = "CharacterInput";
        Field(x => x.Name).Description("The name of the character");
        Field(x => x.Description).Description("The description of the character");
    }
}