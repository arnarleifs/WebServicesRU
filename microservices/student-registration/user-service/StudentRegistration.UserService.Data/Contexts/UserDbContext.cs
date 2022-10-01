using Microsoft.EntityFrameworkCore;

namespace StudentRegistration.UserService.Data.Contexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {}
    }
}