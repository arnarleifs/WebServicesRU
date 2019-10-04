const db = require('../data/db');

module.exports = {
  queries: {
    allLevels: () => db.levels()
  }
}
