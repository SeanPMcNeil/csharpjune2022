#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace manytomanyLecture.Models;

public class Movie
{
    [Key]
    public int MovieId {get;set;}
    public string Title {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    public List<Castlist> ActorsInMovie {get;set;} = new List<Castlist>();
}