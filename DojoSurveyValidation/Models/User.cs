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
}