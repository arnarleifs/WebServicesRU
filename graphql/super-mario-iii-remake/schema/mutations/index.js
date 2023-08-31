const characterMutations = require("./characterMutations");

module.exports = `
  type Mutation {
    ${characterMutations}
  }
`;
