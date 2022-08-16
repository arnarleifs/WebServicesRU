using demo_project.Models;
using GraphQL.Types;

namespace demo_project.Schema.Types;

public sealed class PhotoType : ObjectGraphType<Photo>
{
    public PhotoType()
    {
        Field(x => x.Id).Description("The id of the photo");
        Field(x => x.Name).Description("The name of the photo");
        Field(x => x.Description).Description("The description of the photo");

        Field<StringGraphType>(
            "url",
            description: "The URL of the photo",
            resolve: context => $"https://veft.com/images/{context.Source.Id}"
        );
    }
}

