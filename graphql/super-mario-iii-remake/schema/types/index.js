const character = require('./character');
const level = require('./level');
const bossEnemy = require('./bossEnemy');
const commonEnemy = require('./commonEnemy');

module.exports = `
  ${character}
  ${level}
  ${bossEnemy}
  ${commonEnemy}
`;
