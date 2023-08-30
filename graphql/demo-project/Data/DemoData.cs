using demo_project.Models;

namespace demo_project.Data;

public class DemoData
{
    public List<Transaction> Transactions = new()
    {
        new Transaction
        {
            Id = 1,
            Amount = 500
        },
        new Transaction
        {
            Id = 2,
            Amount = 2500
        },
        new Transaction
        {
            Id = 3,
            Amount = 5000
        }
    };

    public List<Photo> Photos = new()
    {
        new Photo
        {
            Id = "first-family-photo",
            Name = "First family photo",
            Description = "Our first photo as a family",
            Category = PhotoCategory.Landscape,
            UserId = "b753537e-5635-42e3-bddc-f00340fb0e9d"
        },
        new Photo
        {
            Id = "san-francisco",
            Name = "San Francisco",
            Description = "Lovely time at a local coffee shop in San Francisco!",
            Category = PhotoCategory.Portrait,
            UserId = "b753537e-5635-42e3-bddc-f00340fb0e9d"
        },
        new Photo
        {
            Id = "scuba-diving",
            Name = "Scuba diving",
            Description = "The time when we went scuba diving in the Caribbean sea!",
            Category = PhotoCategory.Action,
            UserId = "0ac4b491-2c02-45e4-8de0-2b7f97eb0d7e"
        }
    };

    public List<User> Users = new()
    {
        new User
        {
            Id = "b753537e-5635-42e3-bddc-f00340fb0e9d",
            Name = "John Triangle"
        },
        new User
        {
            Id = "0ac4b491-2c02-45e4-8de0-2b7f97eb0d7e",
            Name = "Lisa Square"
        }
    };

    public List<Tag> Tags = new()
    {
        new Tag
        {
            PhotoId = "first-family-photo",
            UserId = "b753537e-5635-42e3-bddc-f00340fb0e9d"
        },
        new Tag
        {
            PhotoId = "first-family-photo",
            UserId = "0ac4b491-2c02-45e4-8de0-2b7f97eb0d7e"
        },
        new Tag
        {
            PhotoId = "san-francisco",
            UserId = "0ac4b491-2c02-45e4-8de0-2b7f97eb0d7e"
        },
        new Tag
        {
            PhotoId = "scuba-diving",
            UserId = "b753537e-5635-42e3-bddc-f00340fb0e9d"
        },
    };
}