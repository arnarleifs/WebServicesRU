const request = require('request');
const fs = require('fs');
const zlib = require('zlib');

const ruHtmlCompressedStream = fs.createWriteStream('ru.html.gz');

request.get('http://ru.is').pipe(zlib.createGzip()).pipe(ruHtmlCompressedStream);


request.get('https://s3.amazonaws.com/37assets/svn/1065-IMG_2529.jpg').pipe(fs.createWriteStream('profile.jpg'))
