const db = require('../data/db');

module.exports = {
  queries: {
    allCharacters: () => db.characters
  },
  mutations: {
    createCharacter: (parent, args) => {
      const id = args.input.name.toLowerCase().replace(' ', '-');
      const newCharacter = {
        id,
        name: args.input.name,
        description: args.input.description
      };
      db.characters.push(newCharacter);
      return newCharacter;
    },
    updateCharacter: (parent, args /* { id: '', description: '' } */) => {
      const character = db.characters.find(c => c.id === args.id);
      character.description = args.description;
      db.characters = db.characters.map(c => {
        if (c.id === character.id) {
          return character;
        }
        return c;
      });
      return character;
    },
    deleteCharacter: (parent, args) => {
      db.characters = db.characters.filter(c => c.id !== args.id);
      return true;
    }
  }
};
