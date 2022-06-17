#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace manytomanyLecture.Models;
public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Castlist> Castlists { get; set; }
}