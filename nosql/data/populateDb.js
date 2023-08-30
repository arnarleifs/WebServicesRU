import ufoCollection from "./collection.js";
import mongoDb from "mongodb";
const MongoClient = mongoDb.MongoClient;

const args = process.argv.slice(2);
const connectionString = args[0];

const dbName = connectionString.split("/").slice(-1)[0];

(async () => {
  const client = await MongoClient.connect(connectionString, {
    useNewUrlParser: true,
    useUnifiedTopology: true,
  });
  const database = client.db(dbName);

  const ufoTypes = database.collection("ufotypes");
  const ufos = database.collection("ufos");

  // Populate ufo types
  if ((await ufoTypes.countDocuments()) === 0) {
    const result = await ufoTypes.insertMany(
      ufoCollection
        .filter(
          (value, index, self) =>
            self.indexOf(self.find((s) => s.type === value.type)) === index
        )
        .map((u) => ({ type: u.type }))
    );

    console.log(result);
  }

  // Populate ufos
  if ((await ufos.countDocuments()) === 0) {
    const types = await ufoTypes.find({}).toArray();
    const result = await ufos.insertMany(
      ufoCollection.map((u) => {
        return {
          name: u.name,
          description: u.description,
          dateOfDiscovery: u.dateOfDiscovery,
          type: mongoDb.ObjectId(types.find((t) => t.type === u.type)._id),
        };
      })
    );
    console.log(result);
  }

  client.close();
})();
