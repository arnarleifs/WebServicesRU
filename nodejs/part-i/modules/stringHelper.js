
function splitOnChar(str, splitter) {
  return str.split(splitter);
};

function capitalize(str) {
  return str.split(' ').map(s => s.slice(0, 1).toUpperCase() + s.slice(1)).join(' ');
};

module.exports = {
  splitOnChar,
  capitalize
};
