const Ufo = require("../data/db").Ufo;

const globalTryCatch = async (cb) => {
  try {
    return await cb();
  } catch (err) {
    return err;
  }
};

const getAllUfos = async () => {
  return await globalTryCatch(async () => {
    const ufos = await Ufo.find({});
    return ufos;
  });
};

const getUfoById = async (id) => {
  try {
    const ufo = await Ufo.findById(id);
    return ufo;
  } catch (err) {
    return err;
  }
};

function createNewUfo(ufo, successCb, errorCb) {
  Ufo.create(ufo, function (err, result) {
    if (err) {
      errorCb(err);
    } else {
      successCb(result);
    }
  });
}

function updateUfo(ufo, id, successCb, errorCb) {
  Ufo.updateOne({ _id: id }, ufo, function (err, result) {
    if (err) {
      errorCb(err);
    } else {
      successCb();
    }
  });
}

function deleteUfo(id, successCb, errorCb) {
  Ufo.deleteOne({ _id: id }, function (err, result) {
    if (err) {
      errorCb(err);
    } else {
      successCb();
    }
  });
}

module.exports = {
  getAllUfos,
  getUfoById,
  createNewUfo,
  updateUfo,
  deleteUfo,
};
