const MongoClient = require("mongodb").MongoClient;
const {
  DBHOST,
  DBNAME,
  DBUSER,
  DBPWD,
} = require(`../config/database.${process.env.NODE_ENV}.config.js`);

let connection;

module.exports = async () => {
  if (connection) {
    return connection.db(DBNAME);
  }

  connection = await MongoClient.connect(
    DBUSER && DBPWD
      ? `mongodb://${DBUSER}:${DBPWD}@${DBHOST}/${DBNAME}`
      : `mongodb://${DBHOST}/${DBNAME}`,
    {
      useNewUrlParser: true,
      useUnifiedTopology: true,
    }
  );

  return connection.db(DBNAME);
};
