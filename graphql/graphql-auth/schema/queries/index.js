import gql from "graphql-tag";
import secretQueries from "./secretQueries.js";

export default gql`
    type Query {
        ${secretQueries}
    }
`;
