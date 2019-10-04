const db = require('../data/db');
const allEnemies = [ ...db.bosses, ...db.enemies ];

module.exports = {
  queries: {
    allEnemies: () => allEnemies,
    enemy: (parent, args) => allEnemies.find(e => e.id === args.id)
  },
  types: {
    Enemy: {
      __resolveType: (obj) => {
        if (obj.appearsInLevelId) {
          return 'BossEnemy';
        }
        if (obj.enemySize) {
          return 'CommonEnemy';
        }
      }
    },
    BossEnemy: {
      appearsInLevel: parent => db.levels().then(levels => levels.find(l => l.id === parent.appearsInLevelId)),
      unlocksLevels: parent => db.bossUnlockLevels
            // Get all level ids associated with current boss
            .filter(b => b.enemyId === parent.id)
            // Get all levels associated with current boss
            .map(b => db.levels().then(levels => levels.find(l => l.id === b.levelId)))
    }
  }
}
