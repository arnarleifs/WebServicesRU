const mongoose = require("mongoose");
const Schema = mongoose.Schema;

module.exports = new Schema({
  name: { type: String, required: true },
  profileImg: String,
  movieId: Schema.Types.ObjectId,
});
