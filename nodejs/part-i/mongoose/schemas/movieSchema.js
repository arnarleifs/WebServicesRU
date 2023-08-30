const Schema = require("mongoose").Schema;

module.exports = new Schema({
  title: { type: String, required: true },
  publishYear: { type: Number, required: true },
  category: { type: String, required: true, lowercase: true },
  // Optional
  director: String,
});
