const Schema = require("mongoose").Schema;

module.exports = new Schema({
  name: { type: String, required: true },
  description: String,
  type: { type: Schema.Types.ObjectId, required: true },
  dateOfDiscovery: { type: Date, required: true },
});
