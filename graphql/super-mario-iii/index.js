const { ApolloServer } = require('apollo-server');
const typeDefs = require('./schema');

const server = new ApolloServer({
  typeDefs
  /* resolvers */
});

server.listen().then(({ url }) => console.log(`Server is listening on ${url}`));
