module.exports = {
    bosses: [
        {
            id: 'baby-bowser',
            name: 'Baby Bowser',
            hp: 10,
            appearsInLevelId: 'first-level'
        },
        {
            id: 'kamek',
            name: 'Kamek',
            hp: 15,
            appearsInLevelId: 'third-level'
        },
        {
            id: 'bowser',
            name: 'Bowser',
            hp: 25,
            appearsInLevelId: 'fifth-level'
        }
    ],
    enemies: [
        {
            id: 'goomba',
            name: 'Goomba',
            hp: 1,
            enemySize: 'SMALL'
        },
        {
            id: 'hammer-bro',
            name: 'Hammer Bro',
            hp: 1,
            enemySize: 'MEDIUM'
        },
        {
            id: 'lakitu',
            name: 'Lakitu',
            hp: 2,
            enemySize: 'LARGE'
        }
    ],
    bossUnlockLevels: [
        {
            enemyId: 'baby-bowser',
            levelId: 'second-level'
        },
        {
            enemyId: 'baby-bowser',
            levelId: 'third-level'
        },
        {
            enemyId: 'kamek',
            levelId: 'fourth-level'
        },
        {
            enemyId: 'kamek',
            levelId: 'fifth-level'
        },
        {
            enemyId: 'bowser',
            levelId: 'credits'
        }
    ],
    characters: [
        {
            id: 'mario',
            name: 'Mario',
            description: 'Plumber wearing red clothes'
        },
        {
            id: 'luigi',
            name: 'Luigi',
            description: 'Plumber wearing green clothes'
        },
        {
            id: 'peach',
            name: 'Peach',
            description: 'The princess of the Mushroom Kingdom'
        }
    ],
    levels: () => {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve([
                    {
                        id: 'first-level'
                    },
                    {
                        id: 'second-level'
                    },
                    {
                        id: 'third-level'
                    },
                    {
                        id: 'fourth-level'
                    },
                    {
                        id: 'fifth-level'
                    },
                    {
                        id: 'credits'
                    }
                ]);
            }, 1000);
        })
    }
}
