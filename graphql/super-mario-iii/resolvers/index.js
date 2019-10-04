const enemyResolver = require('./enemyResolver');
const characterResolver = require('./characterResolver');
const levelResolver = require('./levelResolver');

module.exports = {
  Query: {
    ...enemyResolver.queries,
    ...characterResolver.queries,
    ...levelResolver.queries
  },
  Mutation: {
    ...characterResolver.mutations
  },
  ...enemyResolver.types
};
