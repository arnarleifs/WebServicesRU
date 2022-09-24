using GraphQL.Types;

namespace demo_project.Schema.Scalar;

public class IskCurrency : ScalarGraphType
{
    public override object? ParseValue(object? value) => value;

    public override object? Serialize(object? value) => $"{value?.ToString()} ISK";
}