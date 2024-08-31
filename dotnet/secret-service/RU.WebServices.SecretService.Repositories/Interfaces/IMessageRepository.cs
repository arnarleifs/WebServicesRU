using System.Collections.Generic;
using RU.WebServices.SecretService.Models.DTOs;
using RU.WebServices.SecretService.Models.InputModels;

namespace RU.WebServices.SecretService.Repositories.Interfaces;

public interface IMessageRepository
{
    int StoreMessage(MessageInputModel message, string userName);
    MessageDetailsDto ReadMessage(int messageId, string userName);
    IEnumerable<MessageDto> ListMessages(string userName);
}