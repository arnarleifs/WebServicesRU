import express from "express";
import fs from "fs";

const app = express();
const port = process.env.PORT || 3000;

app.get("/api/pokemons/:pokemonId/image", (req, res) => {
  const { pokemonId } = req.params;
  const filePath = `./sprites/${pokemonId}.png`;

  fs.readFile(filePath, (err, data) => {
    if (err) {
      return res.status(404).send("Image not found");
    }

    res.setHeader("Content-Type", "image/png");
    res.send(data);
  });
});

app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});
