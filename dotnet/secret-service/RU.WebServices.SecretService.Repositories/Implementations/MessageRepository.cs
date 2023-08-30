using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RU.WebServices.SecretService.Models.DTOs;
using RU.WebServices.SecretService.Models.Entities;
using RU.WebServices.SecretService.Models.InputModels;
using RU.WebServices.SecretService.Repositories.Contexts;
using RU.WebServices.SecretService.Repositories.Interfaces;

namespace RU.WebServices.SecretService.Repositories.Implementations
{
    public class MessageRepository : IMessageRepository
    {
        private readonly SecretServiceDbContext _dbContext;

        public MessageRepository(SecretServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<MessageDto> ListMessages(string userName)
        {
            return _dbContext.Messages.Where(m => m.UserTo.Email == userName).Select(m => new MessageDto
            {
                Id = m.Id,
                CreatedOn = m.CreatedOn
            });
        }

        public MessageDetailsDto ReadMessage(int messageId, string userName)
        {
            var message = _dbContext.Messages.Include(m => m.UserFrom).Include(m => m.UserTo).FirstOrDefault(m => m.UserTo.Email == userName && m.Id == messageId);
            if (message == null) { throw new KeyNotFoundException(); }
            return new MessageDetailsDto
            {
                Id = message.Id,
                Message = message.EncryptedMessage,
                CreatedOn = message.CreatedOn,
                To = message.UserTo.Name,
                From = message.UserFrom.Name
            };
        }

        public int StoreMessage(MessageInputModel message, string userName)
        {
            var userFrom = _dbContext.Users.FirstOrDefault(u => u.Email == userName);
            if (userFrom == null) { throw new Exception("User from not found."); }
            var entity = new Message
            {
                EncryptedMessage = message.Message,
                CreatedOn = DateTime.UtcNow,
                UserToId = message.UserToId,
                UserFromId = userFrom.Id
            };
            _dbContext.Messages.Add(entity);
            _dbContext.SaveChanges();

            return entity.Id;
        }
    }
}