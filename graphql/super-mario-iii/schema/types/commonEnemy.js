module.exports = `
  """
  A common enemy in the mario world.
  """
  type CommonEnemy implements Enemy {
    id: ID!
    name: String!
    hp: Int!
    enemySize: EnemySize!
  }
`;
