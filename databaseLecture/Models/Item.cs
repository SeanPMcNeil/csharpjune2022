#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace databaseLecture.Models;

public class Item
{
    // We need an ID
    // Make sure this is the name of your model + Id
    [Key]
    public int ItemId {get;set;}
    [Required]
    public string Name {get;set;}
    [Required]
    [MinLength(10)]
    public string Description {get;set;}
    // We always include a CreatedAt & UpdatedAt b/c it's good practice
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}