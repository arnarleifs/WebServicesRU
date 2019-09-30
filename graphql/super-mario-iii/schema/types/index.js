const character = require('./character');
const bossEnemy = require('./bossEnemy');
const commonEnemy = require('./commonEnemy');
const level = require('./level');

module.exports = `
  ${character}
  ${bossEnemy}
  ${commonEnemy}
  ${level}
`;
