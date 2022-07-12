using GraphQL.Types;
using super_mario_iii_remake.Data;
using super_mario_iii_remake.Schema.Interfaces;

namespace super_mario_iii_remake.Schema.Types;

public class BossEnemy : IEnemy
{
    public string Id { get; set; } = null!;
    public string? Name { get; set; }
    public int Health { get; set; }
    public IEnumerable<Level>? AppearsInLevel { get; set; }
    public IEnumerable<Level>? UnlocksLevel { get; set; }
}

public sealed class BossEnemyType : ObjectGraphType<BossEnemy>
{
    public BossEnemyType(SMBData data)
    {
        Field(x => x.Id).Description("The id of the boss.");
        Field(x => x.Name).Description("The name of the boss.");
        Field(x => x.Health).Description("The total health of the boss. (HP)");

        FieldAsync<LevelType>(
            "appearsInLevel",
            description: "The level this boss appears in.",
            resolve: async context =>
            {
                var boss = data.Bosses.FirstOrDefault(b => b.Id == context.Source.Id);
                var levels = await data.GetLevels();

                return levels.FirstOrDefault(l => l.Id == boss?.AppearsInLevelId);
            });

        Field<ListGraphType<LevelType>>(
            "unlocksLevels",
            description: "The levels this boss unlocks when beaten.",
            resolve: context =>
            {
                var levels = data.UnlockLevels;
                return levels.Where(l => l.EnemyId == context.Source.Id).ToList().ConvertAll(l => new Level
                {
                    Id = l.LevelId
                });
            });

        Interface<EnemyInterface>();
        IsTypeOf = obj => obj is BossEnemy;
    }
}