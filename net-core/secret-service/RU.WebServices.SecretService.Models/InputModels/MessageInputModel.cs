using System.ComponentModel.DataAnnotations;

namespace RU.WebServices.SecretService.Models.InputModels
{
    public class MessageInputModel
    {
        [Required]
        public string Message { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int UserToId { get; set; }
    }
}