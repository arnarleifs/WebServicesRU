using System.Text;
using System.Text.Json;
using RabbitMQ.Client.Events;
using StudentRegistration.UserService.Data.Contexts;
using StudentRegistration.UserService.Data.Entities;
using StudentRegistration.UserService.Models.Transits;
using StudentRegistration.UserService.Services.Implementations;
using StudentRegistration.UserService.Services.Interfaces;

namespace StudentRegistration.UserService.Console.Handlers
{
    public class StudentRegisterHandler : IHandler
    {
        private readonly UserDbContext _dbContext;
        private readonly IQueueService _queueService;

        public StudentRegisterHandler(UserDbContext dbContext, IQueueService queueService)
        {
            _dbContext = dbContext;
            _queueService = queueService;
        }

        public void Handle(BasicDeliverEventArgs arguments)
        {
            var body = arguments.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var inputModel = JsonSerializer.Deserialize<StudentRegistrationTransit>(message);
            if (inputModel == null) { throw new Exception("The input model cannot be null."); }

            var username = UsernameGenerationService.GenerateUsername(inputModel.FullName, inputModel.Semester);

            if (_dbContext.Users.Any(u => u.UserName == username)) { throw new Exception($"The username '{username}' is already taken."); }

            _dbContext.Users.Add(new User
            {
                Email = inputModel.Email,
                UserName = username,
                FullName = inputModel.FullName,
                Address = inputModel.Address,
                City = inputModel.City,
                PostalCode = inputModel.PostalCode
            });

            _dbContext.SaveChanges();

            _queueService.PublishTopic<StudentRegistrationTransit>("student-registration", inputModel);
        }
    }
}