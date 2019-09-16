const mongoose = require('mongoose');
const actorSchema = require('../schemas/actorSchema');
const movieSchema = require('../schemas/movieSchema');

const connection = mongoose.createConnection('mongodb://veft_dbuser:Abc.12345@ds123513.mlab.com:23513/veft-nodejs', {
  useNewUrlParser: true,
  useUnifiedTopology: true
});

const Actor = connection.model('Actor', actorSchema);
const Movie = connection.model('Movie', movieSchema);

module.exports = {
  connection,
  Actor,
  Movie
};
