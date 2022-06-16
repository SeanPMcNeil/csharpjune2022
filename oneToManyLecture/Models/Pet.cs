#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace oneToManyLecture.Models;

public class Pet
{
    [Key]
    public int PetId {get;set;}
    [Required]
    public string Name {get;set;}
    [Required]
    public string Species {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    [Required]
    public int OwnerId {get;set;}
    //Navigation property for related Owner object
    public Owner? Owner {get;set;}
}