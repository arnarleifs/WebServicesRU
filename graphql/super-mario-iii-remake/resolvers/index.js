const characterResolver = require("./characterResolver");
const enemyResolver = require("./enemyResolver");
const levelResolver = require("./levelResolver");

module.exports = {
  Query: {
    ...characterResolver.queries,
    ...enemyResolver.queries,
    ...levelResolver.queries,
  },
  Mutation: {
    ...characterResolver.mutations,
  },
  ...enemyResolver.types,
};
