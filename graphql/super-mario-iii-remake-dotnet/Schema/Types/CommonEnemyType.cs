using GraphQL.Types;
using super_mario_iii_remake.Schema.Interfaces;

namespace super_mario_iii_remake.Schema.Types;

public enum EnemySize
{
    Small, Medium, Large
}

public class CommonEnemy : IEnemy
{
    public string Id { get; set; } = null!;
    public string? Name { get; set; }
    public int Health { get; set; }
    public EnemySize Size { get; set; }
}

public sealed class CommonEnemyType : ObjectGraphType<CommonEnemy>
{
    public CommonEnemyType()
    {
        Field(x => x.Id).Description("The id of the enemy.");
        Field(x => x.Name).Description("The name of the enemy.");
        Field(x => x.Health).Description("The total health of the enemy. (HP)");
        Field(x => x.Size).Description("The size of the enemy.");

        Interface<EnemyInterface>();
        IsTypeOf = obj => obj is CommonEnemy;
    }
}