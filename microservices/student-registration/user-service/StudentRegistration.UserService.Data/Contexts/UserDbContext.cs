using Microsoft.EntityFrameworkCore;
using StudentRegistration.UserService.Data.Entities;

namespace StudentRegistration.UserService.Data.Contexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; } = null!;
    }
}