#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace databaseLecture.Models;
public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    // the "Items" table name will come from the DbSet property name
    public DbSet<Item> Items { get; set; } 
}