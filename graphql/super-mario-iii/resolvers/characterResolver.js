const db = require('../data/db');

module.exports = {
  queries: {
    allCharacters: () => db.characters
  },
  mutations: {
    createCharacter: (parent, args) => {
      const newCharacter = {
        id: args.input.name.toLowerCase().replace(' ', '-'),
        ...args.input
      };
      db.characters.push(newCharacter);

      return newCharacter;
    },
    updateCharacter: (parent, args) => {
      const character = db.characters.find(c => c.id === args.id);

      // Update description;
      character.description = args.description;

      return character;
    },
    deleteCharacter: (parent, args) => {
      const character = db.characters.find(c => c.id === args.id);
      const index = db.characters.indexOf(character);

      if (index === -1) { return false; }

      db.characters.splice(index, 1);

      return true;
    }
  }
}
