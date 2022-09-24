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
            "totalPhotos",
            resolve: context => data.Photos.Count
        );

        Field<ListGraphType<PhotoType>>(
            "allPhotos",
            resolve: context => data.Photos
        );

        Field<ListGraphType<UserType>>(
            "allUsers",
            resolve: context => data.Users
        );

        Field<ListGraphType<TransactionType>>(
            "allTransactions",
            resolve: context => data.Transactions
        );
    }
}