module.exports = `
  type Mutation {
    createCharacter(input: CharacterInput!): Character!
    updateCharacter(id: Int! description: String!): Character!
    deleteCharacter(id: Int!): Boolean!
  }
`;
