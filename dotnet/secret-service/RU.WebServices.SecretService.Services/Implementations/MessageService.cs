using System.Collections.Generic;
using RU.WebServices.SecretService.Models.DTOs;
using RU.WebServices.SecretService.Models.InputModels;
using RU.WebServices.SecretService.Repositories.Interfaces;
using RU.WebServices.SecretService.Services.Interfaces;

namespace RU.WebServices.SecretService.Services.Implementations;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;
    private readonly ICryptoService _cryptoService;

    public MessageService(IMessageRepository messageRepository, ICryptoService cryptoService)
    {
        _messageRepository = messageRepository;
        _cryptoService = cryptoService;
    }

    public IEnumerable<MessageDto> ListMessages(string userName)
    {
        return _messageRepository.ListMessages(userName);
    }

    public MessageDetailsDto ReadMessage(int messageId, string userName)
    {
        var message = _messageRepository.ReadMessage(messageId, userName);
        message.Message = _cryptoService.Decrypt(message.Message);
        return message;
    }

    public int StoreMessage(MessageInputModel message, string userName)
    {
        message.Message = _cryptoService.Encrypt(message.Message);
        return _messageRepository.StoreMessage(message, userName);
    }
}