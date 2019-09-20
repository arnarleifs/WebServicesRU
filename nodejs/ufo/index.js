const ufoService = require('./services/ufoService');
const express = require('express');
const bodyParser = require('body-parser');
const app = express();

app.use(bodyParser.json());

// http://localhost:3000/api/ufos [GET]
app.get('/api/ufos', async function(req, res) {
  const result = await ufoService.getAllUfos();
  return res.json(result);
});

app.get('/api/ufos/:ufoId', async function(req, res) {
  const ufoId = req.params.ufoId;
  const ufo = await ufoService.getUfoById(ufoId);
  return res.json(ufo);
});

app.post('/api/ufos', function(req, res) {
  ufoService.createNewUfo(req.body, function(ufo) {
    return res.status(201).json(ufo);
  }, function(err) {
    return res.status(400).json(err);
  });
});

app.put('/api/ufos/:ufoId', function(req, res) {
  const ufoId = req.params.ufoId;
  const body = req.body;
  ufoService.updateUfo(body, ufoId, function() {
    return res.status(204).send();
  }, function(err) {
    return res.status(400).json(err);
  });
});

// http://localhost:3000/api/ufos/
app.delete('/api/ufos/:ufoId', function(req, res) {
  const ufoId = req.params.ufoId;
  ufoService.deleteUfo(ufoId, function() {
    return res.status(204).send();
  }, function(err) {
    return res.status(400).json(err);
  });
});

// http://localhost:3000
app.listen(3000, function() {
  console.log('Server is listening on port 3000');
});
