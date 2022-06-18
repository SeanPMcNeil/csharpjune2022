#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace weddingPlanner.Models;

public class Wedding
{
    [Key]
    public int WeddingId {get;set;}
    [Required]
    public string WedderOne {get;set;}
    [Required]
    public string WedderTwo {get;set;}
    [Required]
    [DataType(DataType.Date)]
    [FutureDate]
    public DateTime Date {get;set;}
    [Required]
    public string Address {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    [Required]
    public int UserId {get;set;}
    public User? Creator {get;set;}
    public List<Guest> Attendees {get;set;} = new List<Guest>();
}

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Please provide a date for the wedding");
        }
        if (((DateTime)value) < DateTime.Now)
        {
            return new ValidationResult("Date must be in the future");
        }
        return ValidationResult.Success;
    }
}