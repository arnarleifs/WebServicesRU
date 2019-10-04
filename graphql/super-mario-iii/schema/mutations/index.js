module.exports = `
  type Mutation {
    createCharacter(input: CharacterInput!): Character!
    updateCharacter(id: String! description: String!): Character!
    deleteCharacter(id: String!): Boolean!
  }
`;
