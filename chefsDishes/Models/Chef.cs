#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace chefsDishes.Models;

public class Chef
{
    [Key]
    public int ChefId {get;set;}
    // Other data you want to save
    [Required]
    public string FirstName {get;set;}
    [Required]
    public string LastName {get;set;}

    [Required]
    [DataType(DataType.Date)]
    [FutureDate]
    [OverEighteen]
    public DateTime DateOfBirth {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    public List<Dish> DishesCreated {get;set;} = new List<Dish>();
}

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Please provide a date of birth");
        }
        if (((DateTime)value) > DateTime.Now)
        {
            return new ValidationResult("Date cannot be greater than today's date");
        }
        return ValidationResult.Success;
    }
}
public class OverEighteenAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Please provide a date of birth");
        }
        DateTime dateOfBirth = (DateTime)value;
        int age = DateTime.Now.Year - dateOfBirth.Year;
        if (age < 18)
        {
            return new ValidationResult("You must be 18 or older to be a Chef");
        }
        return ValidationResult.Success;
    }
}