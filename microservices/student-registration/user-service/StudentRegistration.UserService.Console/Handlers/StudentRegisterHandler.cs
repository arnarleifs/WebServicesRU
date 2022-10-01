using RabbitMQ.Client.Events;
using StudentRegistration.UserService.Data.Contexts;

namespace StudentRegistration.UserService.Console.Handlers
{
    public class StudentRegisterHandler : IHandler
    {
        private readonly UserDbContext _dbContext;

        public StudentRegisterHandler(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(BasicDeliverEventArgs arguments)
        {
            throw new NotImplementedException();
        }
    }
}