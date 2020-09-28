module.exports = `
  type Query {
    allCharacters: [Character!]!
    allLevels: [Level!]!
    allEnemies: [Enemy!]!
    enemy(id: String!): Enemy!
  }
`;
