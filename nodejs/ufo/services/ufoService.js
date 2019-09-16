const Ufo = require('../data/db').Ufo;

function getAllUfos(cb) {
  Ufo.find({}, function(err, ufos) {
    if (err) { throw new Error(err); }
    cb(ufos);
  });
};

function getUfoById(id, cb) {
  Ufo.findById(id, function(err, ufo) {
    if (err) { throw new Error(err); }
    cb(ufo);
  });
};

function createNewUfo(ufo, successCb, errorCb) {
  Ufo.create(ufo, function(err, result) {
    if (err) { errorCb(err); }
    else { successCb(result); }
  });
};

function updateUfo(ufo, id, successCb, errorCb) {
  Ufo.updateOne({ _id: id }, ufo, function(err, result) {
    if (err) { errorCb(err); }
    else { successCb(); }
  });
};

function deleteUfo(id) {

};

module.exports = {
  getAllUfos,
  getUfoById,
  createNewUfo,
  updateUfo,
  deleteUfo
};
