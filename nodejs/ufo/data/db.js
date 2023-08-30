const mongoose = require("mongoose");
const ufoSchema = require("./schemas/ufoSchema");
const ufoTypeSchema = require("./schemas/ufoTypeSchema");

const connection = mongoose.createConnection(
  "mongodb://ufo_dbuser:Abc.12345@ds129051.mlab.com:29051/ufo",
  {
    useNewUrlParser: true,
    useUnifiedTopology: true,
  }
);

const Ufo = connection.model("Ufo", ufoSchema);
const UfoType = connection.model("UfoType", ufoTypeSchema);

module.exports = {
  connection,
  Ufo,
  UfoType,
};
