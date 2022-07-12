using super_mario_iii_remake.Schema.Interfaces;

namespace super_mario_iii_remake.Models;

public class BossInternal : IEnemy
{
    public string Id { get; set; } = null!;
    public string? Name { get; set; }
    public int Health { get; set; }
    public string? AppearsInLevelId { get; set; }
}