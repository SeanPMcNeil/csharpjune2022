using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618
namespace DojoSurveyValidation.Models;

public class User
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; }
    
    [Required]
    public string Dojo { get; set; }

    [Required]
    public string Language { get; set;}

    [MinLength(20)]
    public string? Comment { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [FutureDate]
    public DateTime Date { get; set; }
}

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        
        if (((DateTime)value) > DateTime.Now)
        {
            return new ValidationResult("Date cannot be greater than today's date");
        }
        return ValidationResult.Success;
    }
}

