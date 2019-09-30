module.exports = `
  type Query {
    allEnemies: [Enemy!]!
    allCharacters: [Character!]!
    allLevels: [Level!]!
    enemy(id: Int!): Enemy!
  }
`;
