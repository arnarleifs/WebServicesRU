import { MongoClient } from "mongodb";

const connectionString =
  "mongodb+srv://ufo-user:Abc.12345@cluster0.laksg.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";

export const execDatabaseQuery = async (fn) => {
  const connection = new MongoClient(connectionString, {
    useUnifiedTopology: true,
    useNewUrlParser: true,
  });
  try {
    await connection.connect();
    return await fn(connection.db("myFirstDatabase"));
  } finally {
    await connection.close();
  }
};
