const loadDb = require("../data/db");
const request = require("request-promise-native");
const {
  pokemonImageEndpoint,
} = require(`../config/ws.${process.env.NODE_ENV}.config`);

const getCollection = async () => {
  const db = await loadDb();
  return db.collection("pokemons");
};

module.exports = {
  getAllPokemons: async () => {
    const pokemons = await getCollection();
    return pokemons.find({}).toArray();
  },
  getImageForPokemon: (pokeId) =>
    request.get(`${pokemonImageEndpoint}/api/pokemons/${pokeId}/image`, {
      encoding: null,
    }),
};
