using Microsoft.EntityFrameworkCore;
using StargateUniversity.Software.Contracts.Entities;

namespace StargateUniversity.Software.Services.DAL;

public class FinancialDbContext : DbContext
{
    protected FinancialDbContext(DbContextOptions<FinancialDbContext> options) : base(options) { }

    public DbSet<FinancialRecord> FinancialRecords { get; set; }
}