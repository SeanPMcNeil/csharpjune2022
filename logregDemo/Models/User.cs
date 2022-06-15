#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace logregDemo.Models;

public class User
{
    [Key]
    public int UserId {get;set;}
    [Required]
    public string Username {get;set;}
    [Required]
    [EmailAddress]
    public string Email {get;set;}
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password {get;set;}
    // Anything under [NotMapped] will not go into the DB
    [NotMapped]
    [Compare ("Password")]
    [DataType(DataType.Password)]
    public string PassConfirm {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}