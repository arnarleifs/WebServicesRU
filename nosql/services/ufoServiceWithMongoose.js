import { Ufo, UfoType } from "../data/db.js";
import mongodb from "mongodb";

export const getAllUfos = async () => Ufo.find({});

export const getUfoById = async (id) => Ufo.findById(id);

export const createNewUfo = async (ufo) => {
  const type = await UfoType.findOne({ type: ufo.type });
  if (!type) {
    return;
  } // Invalid

  ufo.type = type._id;
  await Ufo.create(ufo);

  /*
    
    await Ufo.create({ ...ufo, type: type._id });

    */

  return ufo;
};

export const updateUfo = async (ufo, id) => {
  if (ufo.type) {
    // 'predator' || 'prey'
    const type = await UfoType.findOne({ type: ufo.type });
    if (!type) {
      return;
    }
    ufo.type = type._id;
  }

  console.log(await Ufo.updateOne({ _id: id }, ufo));

  return ufo;
};

export const deleteUfo = async (id) => {
  const result = await Ufo.deleteOne({ _id: id });
  if (result.deletedCount === 0) {
    return `Alien with id ${id} was not deleted, because it was not found.`;
  }
  return `Alien with id ${id} was deleted. Number deleted: ${result.deletedCount}`;
};

export const countSummary = async () => {
  return Ufo.aggregate([
    {
      $group: { _id: "$type", count: { $sum: 1 } },
    },
    {
      $project: {
        _id: 0,
        predatorCount: {
          $cond: {
            if: { $eq: [mongodb.ObjectId("614bc1ed284ab5ad20e76f0a"), "$_id"] },
            then: "$$REMOVE",
            else: "$count",
          },
        },
        preyCount: {
          $cond: {
            if: { $eq: [mongodb.ObjectId("614bc1ed284ab5ad20e76f09"), "$_id"] },
            then: "$$REMOVE",
            else: "$count",
          },
        },
      },
    },
  ]);
};
