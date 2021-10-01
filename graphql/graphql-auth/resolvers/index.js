import tokenResolver from "./tokenResolver.js"
import secretResolver from "./secretResolver.js"

export default {
    Query: {
        ...secretResolver.queries
    },
    Mutation: {
        ...tokenResolver.mutations,
        ...secretResolver.mutations
    }
}