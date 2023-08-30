using demo_project.Data;
using demo_project.Models;
using GraphQL.Types;

namespace demo_project.Schema.Types;

public sealed class PhotoType : ObjectGraphType<Photo>
{
    public PhotoType(DemoData data)
    {
        Field(x => x.Id).Description("The id of the photo");
        Field(x => x.Name).Description("The name of the photo");
        Field(x => x.Description).Description("The description of the photo");
        Field(x => x.Category).Description("The category of the photo");

        Field<StringGraphType>("url").Description("The URL of the photo").Resolve(context => $"https://veft.com/images/{context.Source.Id}");
        Field<UserType>("postedBy").Description("The user which posted this photo").Resolve(context => data.Users.FirstOrDefault(u => u.Id == context.Source.UserId));
        Field<ListGraphType<UserType>>("taggedUsers").Description("The users tagged on the photo").Resolve(context =>
        {
            var photoId = context.Source.Id;
            // Filter out all the user ids which are tagged on this photo
            var taggedUserIds = data.Tags.Where(t => t.PhotoId == photoId).Select(t => t.UserId);
            // Retrieve all the users which are part of the user ids list
            return data.Users.Where(u => taggedUserIds.Contains(u.Id));
        });
    }
}

