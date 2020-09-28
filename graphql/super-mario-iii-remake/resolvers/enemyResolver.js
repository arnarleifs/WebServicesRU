const db = require('../data/db');
const enemies = [ ...db.enemies, ...db.bosses ];

module.exports = {
  queries: {
    allEnemies: () => enemies,
    enemy: (parent, args) => {
      return enemies.find(e => e.id === args.id);
    }
  },
  types: {
    BossEnemy: {
      appearsInLevel: (parent, arguments) => {
        return db.levels().then(levels => levels.find(l => l.id === parent.appearsInLevelId))
      },
      unlocksLevels: (parent) => {
        const bossId = parent.id;
        return db.bossUnlockLevels
                .filter(bu => bu.enemyId === bossId)
                .map(bu => ({ id: bu.levelId }));
      }
    },
    Enemy: {
      __resolveType(obj, context, info) {
        if (obj.enemySize) { return 'CommonEnemy'; }
        if (obj.appearsInLevelId) { return 'BossEnemy'; }
      }
    }
  }
};
