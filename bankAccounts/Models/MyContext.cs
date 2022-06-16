#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace bankAccounts.Models;
public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}