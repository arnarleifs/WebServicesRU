const { gql } = require('apollo-server');
const types = require('./types');
const input = require('./input');
const interfaces = require('./interfaces');
const enums = require('./enums');
const queries = require('./queries');
const mutations = require('./mutations');

module.exports = gql`
  ${types}
  ${input}
  ${interfaces}
  ${enums}
  ${queries}
  ${mutations}
`;
