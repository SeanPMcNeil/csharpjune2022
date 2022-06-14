#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace CRUDelicious.Models;

public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    // the "Items" table name will come from the DbSet property name
    public DbSet<Dish> Dishes { get; set; } 
}