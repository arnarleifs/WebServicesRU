const ufoService = require('./services/ufoService');
const express = require('express');
const bodyParser = require('body-parser');
const app = express();

app.use(bodyParser.json());

// http://localhost:3000/api/ufos [GET]
app.get('/api/ufos', function(req, res) {
  ufoService.getAllUfos(function (ufos) {
    return res.json(ufos);
  });
});

app.get('/api/ufos/:ufoId', function(req, res) {
  const ufoId = req.params.ufoId;
  ufoService.getUfoById(ufoId, function(ufo) {
    return res.json(ufo);
  });
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

app.delete('/api/ufos/:ufoId', function(req, res) {
  const ufoId = req.params.ufoId;
  return res.json({ ufoId });
});

// http://localhost:3000
app.listen(3000, function() {
  console.log('Server is listening on port 3000');
});
