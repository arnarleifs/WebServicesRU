const mongoDb = require('mongodb');
const MongoClient = mongoDb.MongoClient;
const connectionString = 'mongodb://veft_dbuser:Abc.12345@ds123513.mlab.com:23513/veft-nodejs';

MongoClient.connect(connectionString, {
  useNewUrlParser: true,
  useUnifiedTopology: true
}, function(err, client) {
  if (err) { throw new Error(err); }
  const db = client.db('veft-nodejs');
  const movies = db.collection('movies');
  const actors = db.collection('actors');

  movies.find({}).toArray(function(err, items) {
    if (err) { throw new Error(err); }
    console.log(items);
  });

  actors.find({}).toArray(function(err, items) {
    if (err) { throw new Error(err); }
    console.log(items);
  });

  movies.find({ _id: mongoDb.ObjectId('5bb72e2efb6fc038040aaac1') }).toArray(function(err, items) {
    if (err) { throw new Error(err); }
    console.log(items);
  });

  client.close();
});
