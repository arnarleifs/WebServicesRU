using System.ComponentModel.DataAnnotations;

namespace RentAWorld.Models.InputModels
{
    public class RentalInputModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(0, 10000000)]
        public decimal? AskingPrice { get; set; }
        public bool? Available { get; set; }
        [MinLength(0)]
        [MaxLength(255)]
        public string Address { get; set; }
        [MinLength(0)]
        [MaxLength(255)]
        public string City { get; set; }
    }
}