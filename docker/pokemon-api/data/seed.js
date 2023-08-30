const loadDb = require("./db");
const request = require("request-promise-native");
const _cliProgress = require("cli-progress");

(async () => {
  const db = await loadDb();
  const pokemons = db.collection("pokemons");
  const bar = new _cliProgress.SingleBar({}, _cliProgress.Presets.rect);

  try {
    let json = JSON.parse(
      await request.get("https://pokeapi.co/api/v2/pokemon")
    );
    bar.start(json.count);
    while (json.next) {
      await pokemons.insertMany(
        json.results.map((p) => {
          const splittedUrl = p.url.split("/");
          return {
            ...p,
            pokeId: splittedUrl[splittedUrl.length - 2],
          };
        })
      );
      bar.increment(json.results.length);
      json = JSON.parse(await request.get(json.next));
    }
    await pokemons.insertMany(json.results);
    bar.increment(json.results.length);
  } catch (err) {
    console.error(err);
  }
})();
