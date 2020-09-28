module.exports = `
  type BossEnemy implements Enemy {
    id: ID!
    name: String!
    hp: Int!
    appearsInLevel: Level!
    unlocksLevels: [Level!]!
  }
`;
