const ChunkEmitter = require("./eventPublisher");

ChunkEmitter.on("chunk", function (chunk) {
  console.log(chunk);
});

ChunkEmitter.on("end", function () {
  console.log("No more chunks for you, my friend.");
});

ChunkEmitter.sendChunk();
ChunkEmitter.sendChunk();
ChunkEmitter.sendChunk();
ChunkEmitter.sendChunk();
