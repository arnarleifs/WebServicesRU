import gql from "graphql-tag";

export default gql`
    input UserInput {
        email: String!
        password: String!
    }
`;