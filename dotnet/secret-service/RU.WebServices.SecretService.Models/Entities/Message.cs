using System;

namespace RU.WebServices.SecretService.Models.Entities;

public class Message
{
    public int Id { get; set; }
    public string EncryptedMessage { get; set; }
    public DateTime CreatedOn { get; set; }

    // Navigation properties
    public int UserToId { get; set; }
    public User UserTo { get; set; }
    public int UserFromId { get; set; }
    public User UserFrom { get; set; }
}