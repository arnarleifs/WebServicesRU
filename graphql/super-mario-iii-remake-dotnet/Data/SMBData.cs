using super_mario_iii_remake.Models;
using super_mario_iii_remake.Schema.Types;

namespace super_mario_iii_remake.Data;

public class SMBData
{
    public List<BossInternal> Bosses = new()
    {
        new BossInternal
        {
            Id = "baby-bowser",
            Name = "Baby Bowser",
            Health = 10,
            AppearsInLevelId = "first-level"
        },
        new BossInternal
        {
            Id = "kamek",
            Name = "Kamek",
            Health = 15,
            AppearsInLevelId = "third-level"
        },
        new BossInternal
        {
            Id = "bowser",
            Name = "Bowser",
            Health = 25,
            AppearsInLevelId = "fifth-level"
        }
    };

    public List<CommonEnemy> Enemies = new()
    {
        new CommonEnemy
        {
            Id = "goomba",
            Name = "Goomba",
            Health = 1,
            Size = EnemySize.Small
        },
        new CommonEnemy
        {
            Id = "hammer-bro",
            Name = "Hammer Bro",
            Health = 2,
            Size = EnemySize.Medium
        },
        new CommonEnemy
        {
            Id = "lakitu",
            Name = "Lakitu",
            Health = 4,
            Size = EnemySize.Large
        }
    };

    public List<BossUnlockLevel> UnlockLevels = new()
    {
        new BossUnlockLevel
        {
            EnemyId = "baby-bowser",
            LevelId = "second-level"
        },
        new BossUnlockLevel
        {
            EnemyId = "baby-bowser",
            LevelId = "third-level"
        },
        new BossUnlockLevel
        {
            EnemyId = "kamek",
            LevelId = "fourth-level"
        },
        new BossUnlockLevel
        {
            EnemyId = "kamek",
            LevelId = "fifth-level"
        },
        new BossUnlockLevel
        {
            EnemyId = "bowser",
            LevelId = "credits"
        }
    };

    public List<Character> Characters = new()
    {
        new Character
        {
            Id = "mario",
            Name = "Mario",
            Description = "Plumber wearing red clothes"
        },
        new Character
        {
            Id = "luigi",
            Name = "Luigi",
            Description = "Plumber wearing green clothes"
        },
        new Character
        {
            Id = "princess-peach",
            Name = "Princess Peach",
            Description = "The princess of the Mushroom Kingdom"
        }
    };

    public async Task<List<Level>> GetLevels()
    {
        // Fake an async call which takes 2 seconds.
        await Task.Delay(2000);

        return new List<Level>
        {
            new Level
            {
                Id = "first-level"
            },
            new Level
            {
                Id = "second-level"
            },
            new Level
            {
                Id = "third-level"
            },
            new Level
            {
                Id = "fourth-level"
            },
            new Level
            {
                Id = "fifth-level"
            },
            new Level
            {
                Id = "credits"
            },
        };
    }
}