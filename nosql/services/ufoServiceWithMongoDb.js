import { execUsingMongoClient } from "../data/db.js";
import mongodb from "mongodb";

export const getAllUfos = async () => {
  return await execUsingMongoClient(async (client) => {
    const ufos = await client.collection("ufos").find({}).toArray();
    return ufos;
  });
};

export const getUfoById = async (id) => {
  return await execUsingMongoClient(async (client) => {
    const ufo = await client
      .collection("ufos")
      .findOne({ _id: mongodb.ObjectId(id) });
    return ufo;
  });
};

export const createNewUfo = async (ufo) => {
  return await execUsingMongoClient(async (client) => {
    await client.collection("ufos").insertOne(ufo);
    return ufo;
  });
};

export const updateUfo = async (ufo, id) => {
  return await execUsingMongoClient(async (client) => {
    console.log(
      await client.collection("ufos").updateOne(
        { _id: mongodb.ObjectId(id) },
        {
          $set: {
            name: ufo.name,
            description: ufo.description,
            type: ufo.type,
            dateOfDiscovery: ufo.dateOfDiscovery,
          },
        }
      )
    );

    return ufo;
  });
};

export const deleteUfo = async (id) => {
  return await execUsingMongoClient(async (client) => {
    const result = await client
      .collection("ufos")
      .deleteOne({ _id: mongodb.ObjectId(id) });
    if (result.deletedCount === 0) {
      return `Alien with id ${id} was not deleted, because it was not found.`;
    }
    return `Alien with id ${id} was deleted. Number deleted: ${result.deletedCount}`;
  });
};

export const countSummary = async () => {
  return await execUsingMongoClient(async (client) => {
    return client
      .collection("ufos")
      .aggregate([
        {
          $group: { _id: "$type", count: { $sum: 1 } },
        },
        {
          $project: {
            _id: 0,
            predatorCount: {
              $cond: {
                if: {
                  $eq: [mongodb.ObjectId("614bc1ed284ab5ad20e76f0a"), "$_id"],
                },
                then: "$$REMOVE",
                else: "$count",
              },
            },
            preyCount: {
              $cond: {
                if: {
                  $eq: [mongodb.ObjectId("614bc1ed284ab5ad20e76f09"), "$_id"],
                },
                then: "$$REMOVE",
                else: "$count",
              },
            },
          },
        },
      ])
      .toArray();
  });
};
