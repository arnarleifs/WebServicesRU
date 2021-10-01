import { ApolloServer } from 'apollo-server';
import typeDefs from './schema/index.js';
import resolvers from './resolvers/index.js';
import context from './context/index.js';

const server = new ApolloServer({
    typeDefs,
    resolvers,
    context
});

server.listen() // Port 4000
    .then(({ url }) => console.log(`Listening on ${url}`));