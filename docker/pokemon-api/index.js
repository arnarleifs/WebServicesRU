const express = require('express');
const app = express();
const port = process.env.PORT || 3000;
const pokemonService = require('./services/pokemonService');

app.get('/api/pokemons', async (req, res) => res.json(await pokemonService.getAllPokemons()));

app.get('/api/pokemons/:pokemonId/image', async (req, res) => {
    res.set('Content-Type', 'image/png');

    res.send(await pokemonService.getImageForPokemon(req.params.pokemonId));
});

app.listen(port, () => console.log(`Listening on port ${port}`));
