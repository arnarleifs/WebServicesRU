using GraphQL;
using GraphQL.Types;
using demo_project.Data;
using demo_project.Models;
using demo_project.Schema.InputTypes;
using demo_project.Schema.Types;

namespace demo_project.Mutations;

public class DemoMutations : ObjectGraphType
{
    public DemoMutations(DemoData data)
    {
        Field<PhotoType>("postPhoto")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<PhotoInputType>> { Name = "photo" }
            )).Resolve(context =>
            {
                var input = context.GetArgument<PhotoInput>("photo");

                var photo = new Photo
                {
                    Id = input.Name.ToLower().Replace(" ", "-"),
                    Name = input.Name,
                    Description = input.Description
                };

                data.Photos.Add(photo);

                return photo;
            });
    }
}