using demo_project.Models;
using demo_project.Schema.Scalar;
using GraphQL.Types;

namespace demo_project.Schema.Types;

public sealed class TransactionType : ObjectGraphType<Transaction>
{
    public TransactionType()
    {
        Field(x => x.Id).Description("The id of the transaction");
        Field<IskCurrency>(
            "amount",
            description: "The amount of the transaction",
            resolve: context => context.Source.Amount);
    }
}