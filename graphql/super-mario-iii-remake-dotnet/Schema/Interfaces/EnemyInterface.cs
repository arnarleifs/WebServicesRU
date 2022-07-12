using GraphQL.Types;

namespace super_mario_iii_remake.Schema.Interfaces;

public interface IEnemy
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public int Health { get; set; }
}

public sealed class EnemyInterface : InterfaceGraphType<IEnemy>
{
    public EnemyInterface()
    {
        Field(x => x.Id).Description("The id of the enemy.");
        Field(x => x.Name).Description("The name of the enemy.");
        Field(x => x.Health).Description("The total health of the enemy. (HP)");
    }
}