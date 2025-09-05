namespace RentAWorld.Models.InputModels;

public class RentalPartialInputModel
{
    /// <summary>
    /// The title of the rental
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// The description of the rental
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The asking price of the rental
    /// </summary>
    public int? AskingPrice { get; set; }

    /// <summary>
    /// Determines whether the rental is available or not
    /// </summary>
    public bool? Available { get; set; }

    /// <summary>
    /// The address of the rental
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// The city location of the rental
    /// </summary>
    public string? City { get; set; }
}