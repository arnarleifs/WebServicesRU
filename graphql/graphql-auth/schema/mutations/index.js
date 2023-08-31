import gql from "graphql-tag";
import secretMutations from "./secretMutations.js";
import tokenMutations from "./tokenMutations.js";

export default gql`
    type Mutation {
        ${secretMutations}
        ${tokenMutations}
    }
`;
