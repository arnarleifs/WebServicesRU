import gql from "graphql-tag";
import queries from './queries/index.js';
import mutations from './mutations/index.js';
import inputs from './inputs/index.js';

export default gql`
    ${queries}
    ${mutations}
    ${inputs}
`;