using GraphQL;
using GraphQL.Types;
using demo_project.Data;
using demo_project.Schema.Types;

namespace demo_project.Queries;

public class DemoQuery : ObjectGraphType
{
    public DemoQuery(DemoData data)
    {
        Field<IntGraphType>(
            "totalPhotos"
        ).Resolve(context => data.Photos.Count);

        Field<ListGraphType<PhotoType>>(
            "allPhotos"
        ).Resolve(context => data.Photos);

        Field<ListGraphType<UserType>>(
            "allUsers"
        ).Resolve(context => data.Users);

        Field<ListGraphType<TransactionType>>(
            "allTransactions"
        ).Resolve(context => data.Transactions);
    }
}