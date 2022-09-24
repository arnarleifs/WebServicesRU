namespace demo_project.Models;

public class Photo
{
    public string? Id { get; set; }
    public string? Url { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public PhotoCategory Category { get; set; }
    public string? UserId { get; set; }
}

