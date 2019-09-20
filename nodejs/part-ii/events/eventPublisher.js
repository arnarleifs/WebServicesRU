const EventEmitter = require('events');

class ChunkEmitter extends EventEmitter {
  constructor() {
    super();
    this.properties = {
      data: [ 'Chunk 1', 'Chunk 2', 'Chunk 3' ],
      currentChunk: 1
    };
  }
  sendChunk() {
    if (this.properties.currentChunk <= this.properties.data.length) {
      this.emit('chunk', this.properties.data[ this.properties.currentChunk - 1 ]);
      this.properties.currentChunk = this.properties.currentChunk + 1;
    } else {
      this.emit('end');
    }
  }
}

module.exports = new ChunkEmitter();
