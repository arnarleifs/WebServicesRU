
export default next /* Resolver function */ => (parent, args, context, info) => {
    if (!context.currentUser) {
        throw new Error('Unauthorized');
    }

    return next(parent, args, context, info);
}