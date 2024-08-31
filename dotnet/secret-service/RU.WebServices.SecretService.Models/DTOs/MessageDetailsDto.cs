using System;

namespace RU.WebServices.SecretService.Models.DTOs;

public class MessageDetailsDto
{
    public int Id { get; set; }
    public string Message { get; set; }
    public DateTime CreatedOn { get; set; }
    public string To { get; set; }
    public string From { get; set; }
}