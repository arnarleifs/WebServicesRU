using GraphQL;
using GraphQL.Types;
using super_mario_iii_remake.Data;
using super_mario_iii_remake.Schema.InputTypes;
using super_mario_iii_remake.Schema.Types;

namespace super_mario_iii_remake.Mutations;

public class SMBMutations : ObjectGraphType
{
    public SMBMutations(SMBData data)
    {
        Field<CharacterType>(
            "createCharacter",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<CharacterInputType>> { Name = "character" }
            ),
            resolve: context =>
            {
                var character = context.GetArgument<CharacterInput>("character");
                var newCharacter = new Character
                {
                    Id = character.Name.ToLower().Replace(" ", "-"),
                    Name = character.Name,
                    Description = character.Description
                };
                data.Characters.Add(newCharacter);

                return newCharacter;
            });
        Field<CharacterType>(
            "updateCharacter",
            arguments: new QueryArguments(
                new QueryArgument<IdGraphType> {Name = "id"},
                new QueryArgument<StringGraphType> {Name = "description"}
            ),
            resolve: context =>
            {
                var id = context.GetArgument<string>("id");
                var description = context.GetArgument<string>("description");

                data.Characters = data.Characters.Select(c =>
                {
                    if (c.Id == id)
                    {
                        return new Character
                        {
                            Id = c.Id,
                            Name = c.Name,
                            // The only one that changes
                            Description = description
                        };
                    }

                    return c;
                }).ToList();

                return data.Characters.FirstOrDefault(c => c.Id == id);
            }
        );
        Field<BooleanGraphType>(
            "deleteCharacter",
            arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "id" }
            ),
            resolve: context =>
            {
                var id = context.GetArgument<string>("id");

                data.Characters = data.Characters.Where(c => c.Id != id).ToList();

                return true;
            }
        );
    }
}