const fs = require('fs');

// fs.access('doesExist', fs.constants.F_OK, function(err) {
//   if (err) {
//     console.log('Does not exist!');
//   } else {
//     fs.appendFile('doesExist', 'Just nod if you can hear me', function(err) {
//       console.log(err);
//     });
//   }
// });


const heManFile = fs.createWriteStream('heman.txt');
heManFile.write('By the power of Grayskull! I have the power!');

fs.readFile('heman.txt', { encoding: 'utf8' }, function(err, data) {
  if (err) {
    throw new Error(err);
  }
  console.log(data);
  fs.unlink('heman.txt', function(err) {
    if (err) {
      throw new Error(err);
    }
    console.log('It was successfully deleted!');
  });
});
