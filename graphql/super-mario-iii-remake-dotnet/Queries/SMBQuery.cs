using GraphQL;
using GraphQL.Types;
using super_mario_iii_remake.Data;
using super_mario_iii_remake.Schema.Interfaces;
using super_mario_iii_remake.Schema.Types;

namespace super_mario_iii_remake.Queries;

public class SMBQuery : ObjectGraphType
{
    public SMBQuery(SMBData data)
    {
        Field<ListGraphType<CharacterType>>("allCharacters").Resolve(context => data.Characters);

        Field<ListGraphType<EnemyInterface>>("allEnemies")
            .Resolve(context =>
            {
                var bosses = data.Bosses.ConvertAll(input => new BossEnemy
                {
                    Id = input.Id,
                    Name = input.Name,
                    Health = input.Health
                }).Cast<IEnemy>();
                var commonEnemies = data.Enemies.Cast<IEnemy>();

                return bosses.Concat(commonEnemies).OrderBy(n => n.Name);
            });

        Field<EnemyInterface>("enemy")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "Id of the enemy" }
            ))
            .Resolve(context =>
            {
                var id = context.GetArgument<string>("id");

                var bosses = data.Bosses.ConvertAll(input => new BossEnemy
                {
                    Id = input.Id,
                    Name = input.Name,
                    Health = input.Health
                }).Cast<IEnemy>().ToList();
                var commonEnemies = data.Enemies.Cast<IEnemy>().ToList();

                var allEnemies = bosses.Concat(commonEnemies).OrderBy(n => n.Name).ToList();
                var enemy = allEnemies.FirstOrDefault(e => e.Id == id);

                return enemy;
            });

        Field<ListGraphType<LevelType>>("allLevels").ResolveAsync(async context => await data.GetLevels());
    }
}