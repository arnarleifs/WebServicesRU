using demo_project.Models;
using GraphQL.Types;

namespace demo_project.Schema.InputTypes;

public class PhotoInput
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public PhotoCategory Category { get; set; }
}

public sealed class PhotoInputType : InputObjectGraphType<PhotoInput>
{
    public PhotoInputType()
    {
        Name = "PhotoInputType";
        Field(x => x.Name).Description("The name of the photo");
        Field(x => x.Description).Description("The description of the photo");
        Field(x => x.Category).Description("The category of the photo");
    }
}