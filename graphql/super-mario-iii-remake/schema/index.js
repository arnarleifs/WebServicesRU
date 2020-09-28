const queries = require('./queries');
const mutations = require('./mutations');
const inputs = require('./inputs');
const interfaces = require('./interfaces');
const types = require('./types');
const enums = require('./enums');

module.exports = `
  ${queries}
  ${mutations}
  ${inputs}
  ${interfaces}
  ${types}
  ${enums}
`;
