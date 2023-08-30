const DataProvider = require("./data");

// DataProvider.Movie.find({}, function(err, movies) {
//   //console.log(movies);
//   DataProvider.Actor.find({}, function(err, actors) {
//     //console.log(actors);
//   });
// });

// DataProvider.Movie.findById('5bb72e2efb6fc038040aaac1', function(err, movie) {
//   console.log(movie);
//   DataProvider.Actor.find({ movieId: movie._id }, function(err, actors) {
//     console.log(actors);
//     DataProvider.connection.close();
//   });
// });

DataProvider.Movie.create(
  {
    title: "Charlie and the Chocolate Factory",
    publishYear: 2005,
    category: "HORROR",
    director: "Tim Burton",
  },
  function (err, movie) {
    if (err) {
      throw new Error(err);
    }
    console.log(movie);
  }
);
