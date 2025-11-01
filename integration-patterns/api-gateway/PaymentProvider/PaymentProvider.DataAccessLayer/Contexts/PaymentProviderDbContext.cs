using Microsoft.EntityFrameworkCore;
using PaymentProvider.DataAccessLayer.Entities;

namespace PaymentProvider.DataAccessLayer.Contexts;

public class PaymentProviderDbContext(DbContextOptions<PaymentProviderDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PaymentLink> PaymentLinks { get; set; }
    public DbSet<PaymentLinkItem> PaymentLinkItems { get; set; }
    public DbSet<Webhook> Webhooks { get; set; }
}