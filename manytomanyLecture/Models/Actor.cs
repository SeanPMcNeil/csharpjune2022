#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace manytomanyLecture.Models;

public class Actor
{
    [Key]
    public int ActorId {get;set;}
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    public List<Castlist> MoviesActedIn {get;set;} = new List<Castlist>();
}