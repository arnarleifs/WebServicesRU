const ApolloServer = require("apollo-server").ApolloServer;
const typeDefs = require("./schema");
const resolvers = require("./resolvers");

const server = new ApolloServer({
  typeDefs,
  resolvers,
});

server
  .listen() // Listens by default port 4000 (http://localhost:4000)
  .then(({ url }) => console.log(`Listening on ${url}`));
